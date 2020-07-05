using System.ComponentModel;

namespace Proventos.Core.Models.Enums
{
    public enum TipoProvento
    {
        [Description("DIVIDENDO")]
        DIVIDENDO = 1,
        [Description("JRS CAP PROPRIO")]
        JRSCAPPROPRIO = 2,
        [Description("BONIFICA��O")]
        BONIFICACAO = 3,
        [Description("DIREITOS DE SUBSCRI��O")]
        DIREITOSUBSCRICAO = 4
    }
}