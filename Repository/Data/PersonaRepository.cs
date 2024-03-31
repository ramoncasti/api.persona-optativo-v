﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;

namespace Repository.Data
{
    public class PersonaRepository : IPersona
    {
        private IDbConnection conexionDB;
        public PersonaRepository(string _connectionString)
        {
           
            conexionDB = new DbConection(_connectionString).dbConnection();
        }
        public bool add(PersonaModel persona)
        {
            try
            {
                if(conexionDB.Execute("Insert into Persona(nombre, apellido, cedula) values(@nombre, @apellido, @cedula)", persona) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public PersonaModel get(int id)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<PersonaModel> list()
        {
                return conexionDB.Query<PersonaModel>("SELECT * FROM Persona").ToList();
        }


        public bool remove(PersonaModel persona)
        {
            try
            {
                var affectedRows = conexionDB.Execute("DELETE FROM Persona WHERE id = @Id");
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool update(PersonaModel persona)
        {
            try
            {
                var affectedRows = conexionDB.Execute("UPDATE Persona SET nombre = @Nombre, apellido = @Apellido, cedula = @Cedula WHERE id = @Id", persona);
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
