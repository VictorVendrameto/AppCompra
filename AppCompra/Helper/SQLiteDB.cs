using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks; 
using AppCompras.Model;
using SQLite;

namespace AppCompras.Helper
{
    
    public class SQLiteDB
    {
        readonly SQLiteAsyncConnection _conec;
        public SQLiteDBH(string path)
        {
            _conec = new SQLiteAsyncConnection(path);
            _conec.CreateTableAsync<Produto>().Wait();
        }


        //insert
        public Task<int> insert(Produto p)
        {
            return _conec.InsertAsync(p);
        }


        //Update
        public void update(Produto p)
        {
            string sql = "UPDATE Produto SET Desc=?, Quant=?, Preco=?"
        }


        //getById
        public Task<Produto> getById(int id)
        {
            return new Produto();
        }


        //getAll
        public Task<List<Produto>> getAll()
        {

        }


        //delete
        public void delete(int id)
        {

        }
    }
}
