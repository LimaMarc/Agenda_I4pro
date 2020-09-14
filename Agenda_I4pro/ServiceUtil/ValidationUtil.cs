using System;
using System.Collections.Generic;

namespace Agenda_I4pro.ServiceUtil
{
    public class ValidationUtil
    {
        public static void EnsureArgumentLength(string stringValue,string message,  byte lengthMin=0)
        {
            int length = stringValue.Trim().Length;
            if (length < lengthMin)
            {
                throw new InvalidOperationException(message);
            }
        }

        public static void EnsureArgumentNotEmpty(string stringValue, string message)
        {
            if (stringValue == null || stringValue.Trim().Length == 0)
            {
                throw new InvalidOperationException(message);
            }
        }

        public static void EnsureArgumentNotNull(object object1, string message)
        {
            if (object1 == null)
            {
                throw new InvalidOperationException(message);
            }
        }

        public static void EnsureStringNotNull(string stringValue, string message)
        {
            if (stringValue == "")
            {
                throw new InvalidOperationException(message);
            }
        }

        public static void EnsureListNotNull(List<string> listObject, string message)
        {
            if (listObject.Count<=0)
            {
                throw new InvalidOperationException(message);
            }
        }

        protected ValidationUtil()
        {
        }


        protected void SelfEnsureArgumentNotEmpty(string stringValue, string message)
        {
            EnsureArgumentNotEmpty(stringValue, message);
        }

        protected void SelfEnsureArgumentNotNull(object object1, string message)
        {
            EnsureArgumentNotNull(object1, message);
        }

        protected void SelfEnsureArgumentLength(string stringValue, string message)
        {
            EnsureArgumentLength(stringValue, message);
        }

    }
}