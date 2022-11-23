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
        public SQLiteDB(string path)
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
        public Task<List<Produto>> update(Produto p)
        {
            string sql = "UPDATE Produto SET Desc=?, Quant=?, Preco=? WHERE id= ? ";
            return _conec.QueryAsync<Produto>(sql, p.desc, p.quant, p.preco, p.id);
        }



        //getAll
        public Task<List<Produto>> getAll()
        {
            return _conec.Table<Produto>().ToListAsync();
        }


        //delete
        public Task<int> delete(int id)
        {
            return _conec.Table<Produto>().DeleteAsync(i => i.id == id);
        }

        public Task<List<Produto>> search(string q)
        {
            string sql = "SELECT FROM * Produto WHERE Desc LIKE '%" + q + "%'";
            return _conec.QueryAsync<Produto>(sql);
        }
    }
}
