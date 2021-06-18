using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PanaderiaDonMario.Controllers
{
    public class Singleton
    {
        private static Singleton instance = null;
        public int id;

        protected Singleton() {
            id = 0;
        }

        public static Singleton Instance
        {
            get{
                if (instance == null)
                    instance = new Singleton();
                return instance;
            }
        }
    }
}