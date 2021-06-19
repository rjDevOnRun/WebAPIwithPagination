using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WebAPIService.DataAccess;
using WebAPIService.Models;

namespace WebAPIService.Repository
{
    public class OrdersRepository
    {
        public static Task<PagedList<Order>> 
            GetOrders(PagingParameter pagingParameter)
        {
            string query = "SELECT * FROM ORDERS";

            var data = SqlDataAccess.LoadData(query);

            List<Order> studentDetails = new List<Order>();
            studentDetails = ConvertDataTable<Order>(data);

            return Task.FromResult(PagedList<Order>.GetPagedList(studentDetails,
                pagingParameter.PageNumber, pagingParameter.PageSize));
        }

        public static List<Order> GetAllOrders()
        {
            string query = "SELECT * FROM ORDERS";

            var data = SqlDataAccess.LoadData(query);

            List<Order> studentDetails = new List<Order>();
            studentDetails = ConvertDataTable<Order>(data);

            return studentDetails;
        }

        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                    {
                        if (dr[column.ColumnName].GetType() != typeof(DBNull))
                        {
                            pro.SetValue(obj, dr[column.ColumnName], null);
                        }
                    }
                    else
                        continue;
                }
            }
            return obj;
        }
    }
}
