using System;
using System.Collections.Generic;

namespace LoginAPI_Tutorial.Entities.LoginDB;

public partial class CurrencysList
{
    public int CurrencyId { get; set; }

    public string CurrencyDescription { get; set; } = null!;
}
