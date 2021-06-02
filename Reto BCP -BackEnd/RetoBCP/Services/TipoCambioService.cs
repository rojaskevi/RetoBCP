using MongoDB.Driver;
using RetoBCP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RetoBCP.Services;

namespace RetoBCP.Services
{
    public class TipoCambioService
    {
        public UsuarioService _usuarioService;
        private IMongoCollection<TipoCambio> _tipoCambio;
        //inyectamos el barSettings
        public TipoCambioService(ITipoCambioSettings settings) {
            var cliente = new MongoClient(settings.Server);
            var database = cliente.GetDatabase(settings.Database);
            _tipoCambio = database.GetCollection<TipoCambio>(settings.Collection);

        }

        public List<TipoCambio> Get() {
            return _tipoCambio.Find(d => true).ToList();
        }

        public CambioMoneda CambioMoneda(string monedaOrigenP, string monedaDestinoP, decimal montoP)
        {
            CambioMoneda b = new CambioMoneda();
            TipoCambio a = (TipoCambio)_tipoCambio.
                                        Find(d => true).ToEnumerable().
                                        Where(d => d.MonedaOrigen== monedaOrigenP).
                                        Where(d => d.MonedaDestino == monedaDestinoP).First();
            b.MonedaOrigen = a.MonedaOrigen;
            b.MonedaDestino = a.MonedaDestino;
            b.Cambio = a.Cambio;
            b.Monto = montoP;
            b.MontoCambiado = b.Monto * b.Cambio;
            return b;
        }

        public TipoCambio Create(TipoCambio tipoCambio)
        {
            _tipoCambio.InsertOne(tipoCambio);
            return tipoCambio;
        }

        public void Update(string id, TipoCambio tipocambio) {
            _tipoCambio.ReplaceOne(tipocambio => tipocambio.Id == id, tipocambio);
        }

        public void Delete(string id) {
            _tipoCambio.DeleteOne(d => d.Id == id);
        }

    }
}
