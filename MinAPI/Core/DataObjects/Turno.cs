using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinAPI.Core.DataObjects
{
    public class Turno
    {
        private int _horas;
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int DesdeHora { get; set; }
        public int HastaHora { get; set; }
        public List<int> DiasSemana { get; set; }
        public int Horas
        {
            get => Math.Abs(_horas);
            set
            {
                _horas = HastaHora - DesdeHora;

                if (_horas == 0) _horas = 24;
            }

        }
    }
}
