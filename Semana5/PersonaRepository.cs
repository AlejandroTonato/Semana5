using Semana5.Modelos;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Semana5
{
    public class PersonaRepository
    {
        string dbPath; //ruta
        private SQLiteAsyncConnection conn; //coneccion
        public string statusMessage {  get; set; }

        private async Task Init()
        {
            if (conn is not null)
                return;
            conn = new (dbPath);
            await conn.CreateTableAsync<Persona>();
        }

        public PersonaRepository(string _dbPath)
        {
            dbPath = _dbPath;
        }

        public async Task AddNewPersona(string name)
        {
            int result = 0;
            try
            {
                await Init();
                if (string.IsNullOrEmpty(name))
                    throw new Exception("El nombre es requerido");
                Persona person = new() { Name = name };
                result = await conn.InsertAsync(person);

                statusMessage = string.Format("{0} record(s) added (Name: {1})", result, name);

            }
            catch (Exception ex)
            {
                statusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
                
            }
        }

        public async Task <List<Persona>> GetAllPersonas()
        {
            try
            {
                await Init();
                return await conn.Table<Persona>().ToListAsync();
            }
            catch (Exception ex)
            {

                statusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Persona>();
        }

        public async Task DeletePerson(int personId)
        {
            try
            {
                await Init();
                int result = await conn.DeleteAsync<Persona>(personId);
                statusMessage = string.Format("Filas eliminadas: {0}", result);
            }
            catch (Exception ex)
            {
                statusMessage = string.Format("Error al eliminar la persona con ID {0}: {1}", personId, ex.Message);
            }
        }

        public async Task UpdatePerson(Persona updatedPerson)
        {
            try
            {
                await Init();
                if (updatedPerson == null)
                    throw new Exception("Persona actualizada no puede ser nula");

                int result = await conn.UpdateAsync(updatedPerson);
                statusMessage = string.Format("Filas actualizadas: {0}", result);
            }
            catch (Exception ex)
            {
                statusMessage = string.Format("Error al actualizar la persona: {0}", ex.Message);
            }
        }





    }
}
