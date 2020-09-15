using Agenda_I4pro.Controllers.ControllerService;
using Agenda_I4pro.Infrasctructure;
using Agenda_I4pro.Models.BusinessModel;
using Agenda_I4pro.Models.ModelViewModel;
using Agenda_I4pro.ServiceUtil;
using System;
using System.Collections.Generic;

using System.Web.Mvc;

namespace Agenda_I4pro.Controllers
{
    public class ContatoController : Controller
    {
        //O padrão S.O.L.I.D especifica que não devemos depender da implementação concreta de classe, pois isso 
        //implica numa alta acoplagem com classes (Fugindo de um dos pilares da POO: Abstração
        //O ideal seria implementar a abstração (Interface) e não a implementação 
        //concreta da Classe. No nosso caso em um ambiente Profissional deveriamos implementar
        //uma Interface da classe ContatoRepositorioDB e passar algum "Container" de IOC.
        ContatoControllerService contatoService;

        //O Mesmo vale para Classe TB_CONTATO - que representa a tabela do nosso Banco de Dados Fictício.
        TB_CONTATO contato;



        #region Construtor do Controller ( Clique para expandir )
        public ContatoController()
        {
            contatoService = new ContatoControllerService();
        }

        #endregion



        #region Métodos do Controller ( Clique para expandir )
    

        public ActionResult Index()
        {

            List<ContatoViewModel> contatoEmail = contatoService.listarContato();
            return View(contatoEmail);

        }


       
        public ActionResult Details(int id)
        {
            List<ContatoDetalheViewModel> contatoViewModel = contatoService.Detalhe(id);
            return View(contatoViewModel);
        }



        public ActionResult Create()
        {


            return View();
        }



        [HttpPost]
        public ActionResult Create(string nome, string sobrenome, List<string> listEmailCriacaoViewModel, List<string> listTelefoneCriacaoModel)
        {
            try
            {
                //Validação no lado do Servidor para garantir que nome e sobreno sejam válidos.                
                ValidationUtil.EnsureArgumentNotEmpty(nome, "Nome em Branco");
                ValidationUtil.EnsureArgumentNotEmpty(sobrenome, "Sobrenome em Branco");

                //Validação no lado do Servidor para garantir que email e telefone sejam válidos.    
                ValidationUtil.EnsureListNotNull(listEmailCriacaoViewModel, "Email em Branco");
                ValidationUtil.EnsureListNotNull(listTelefoneCriacaoModel, "Email em Branco");


                contato = new TB_CONTATO();
                contato.CD_CONTO_NOME = nome;
                contato.CD_CONTO_SOBRENOME = sobrenome;

                contatoService.cadastrarContato(contato, listEmailCriacaoViewModel, listTelefoneCriacaoModel);

                return RedirectToAction("Index", "Contato");

            }
            catch (Exception)
            {
                return RedirectToAction("Create", "Contato");
            }
        }



        public ActionResult Edit(int id)
        {
            ContatoEditarViewModel contatoViewModel = contatoService.exibirContatoViewModel(id);
            return View(contatoViewModel);
        }



        [HttpPost]
        public ActionResult Edit(int id, TB_CONTATOVIEWMODEL tB_CONTATOVIEWMODEL,ICollection<TB_TELEFONEVIEWMODEL> tB_TELEFONEVIEWMODELs, ICollection<TB_EMAILVIEWMODEL> tB_EMAILVIEWMODELs)
        {
            
               if (ModelState.IsValid)
                { 
                    
                contatoService.editarContato(id, tB_CONTATOVIEWMODEL, tB_TELEFONEVIEWMODELs, tB_EMAILVIEWMODELs);


                  return RedirectToAction("Index");
                }
            ContatoEditarViewModel contatoViewModel = new ContatoEditarViewModel();
            contatoViewModel.TB_CONTATOVIEWMODEL = tB_CONTATOVIEWMODEL;
            contatoViewModel.TB_TELEFONEVIEWMODEL = tB_TELEFONEVIEWMODELs;
            contatoViewModel.TB_EMAILVIEWMODEL = tB_EMAILVIEWMODELs;

            return View(contatoViewModel);
            
        }


        public ActionResult Delete(int id)
        {
            contatoService.excluirContato(id);
            List<ContatoViewModel> contatoEmail = contatoService.listarContato();
            return View("Index", contatoEmail);
        }


        #endregion




    }

}
