﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Interfaces;

namespace DAL.Repo
{
    internal class TokenRepo : IRepo<Token, string, Token>
    {
        FundEntities db;
        public TokenRepo(FundEntities db)
        {
            this.db = db;
        }
        public Token Create(Token obj)
        {
            db.Tokens.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<Token> Get()
        {
            throw new NotImplementedException();
        }

        public Token Get(string token)
        {
            return db.Tokens.FirstOrDefault(t => t.AccessToken.Equals(token));
        }

        public bool Update(Token obj)
        {
            var exst = db.Tokens.FirstOrDefault(x => x.AccessToken.Equals(obj.AccessToken));
            if (exst != null)
            {
                db.Entry(exst).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
