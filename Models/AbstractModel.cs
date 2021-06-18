using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PanaderiaDonMario.Models
{
    public abstract class AbstractModel<T> where T : class
    {
        protected PanaderiaEntities ctx = new PanaderiaEntities();

        DbSet<T> dbSet;

        public AbstractModel()
        {
            dbSet = ctx.Set<T>();
        }
        public virtual int Insert(T entity)
        {
            try
            {
                dbSet.Add(entity);
                ctx.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public virtual List<T> List()
        {
            var result = from t in dbSet
                         select t;
            return result.ToList();
        }

        public virtual List<Factura_Inevntario> Detalles(int id)
        {
            var resultado = (from Factura_Inevntario in ctx.Factura_Inevntario
                             where Factura_Inevntario.ID_Factura == id
                             select Factura_Inevntario).ToList();
            return resultado;
        }

        public virtual T GetById(Object id)
        {
            return dbSet.Find(id);
        }

        public virtual Factura Ultimo()
        {
            var res = (from Factura in ctx.Factura orderby Factura.ID_Factura descending select Factura).First();
            return res;
        }

        public virtual int Update(T entity, Object id)
        {
            try
            {
                T old = dbSet.Find(id);
                if (old != null)
                {
                    ctx.Entry(old).CurrentValues.SetValues(entity);
                    ctx.SaveChanges();
                    return 1;
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        public virtual int Remove(Object id)
        {
            try
            {
                T entity = dbSet.Find(id);
                if (entity != null)
                {
                    dbSet.Remove(entity);
                    ctx.SaveChanges();
                    return 1;
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }


    }
}