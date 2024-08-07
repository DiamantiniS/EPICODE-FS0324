﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PoliziaMunicipale.Models
{
    public class Verbale
    {
        public int Id { get; set; }
        public DateTime? DataViolazione { get; set; } // Nullable
        public string IndirizzoViolazione { get; set; }
        public string NominativoAgente { get; set; }
        public DateTime? DataTrascrizioneVerbale { get; set; } // Nullable
        public decimal Importo { get; set; }
        public int DecurtamentoPunti { get; set; }
        public int AnagraficaId { get; set; }
        public Anagrafica Anagrafica { get; set; }
        public List<TipoViolazione> Violazioni { get; set; } = new List<TipoViolazione>();
        public string Descrizione { get; set; }
    }


}
