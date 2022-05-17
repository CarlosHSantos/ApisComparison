using System.ComponentModel;

namespace SharedClasses.Models
{
    public enum Role
    {
        [Description("Visitor")]
        Visitante = 0,
        [Description("Member")]
        Membro = 1,
        [Description("Deacon")]
        Diacono = 2,
        [Description("Worker")]
        Obreiro = 3,
        [Description("Secretary")]
        Secretario = 4,
        [Description("Treasurer")]
        Tesoureiro = 5,
        [Description("Pastor")]
        Pastor = 6,
        [Description("Administrator")]
        Administrador = 7
    }
}
