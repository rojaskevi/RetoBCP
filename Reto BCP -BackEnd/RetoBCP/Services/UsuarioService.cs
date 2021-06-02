using MongoDB.Driver;
using RetoBCP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetoBCP.Services
{
    public class UsuarioService
    {
        private IMongoCollection<Usuario> _usuario;
        //inyectamos el barSettings
        public UsuarioService(IUsuarioSettings settings) {
            var cliente = new MongoClient(settings.Server);
            var database = cliente.GetDatabase(settings.Database);
            _usuario = database.GetCollection<Usuario>(settings.Collection);
        }

        public Usuario Login(String username, string password) {
            Usuario a = (Usuario)_usuario.
                                        Find(d => true).ToEnumerable().
                                        Where(d => d.user == username).
                                        Where(d => d.password == password).First();
            a.token = Guid.NewGuid().ToString();

            _usuario.ReplaceOne(usuario => usuario.Id == a.Id, a);
            return a;
        }

        public Usuario ValidarToken(string token) {
            Usuario a = (Usuario)_usuario.
                                            Find(d => true).ToEnumerable().
                                            Where(d => d.token == token).First();
            return a;
        }

    }
}
