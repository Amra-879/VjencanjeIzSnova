using System;
using System.Collections.Generic;

namespace VjencanjeIzSnova_July.Models;

public partial class Planer
{
    public int PlanerId { get; set; }

    public string UserId { get; set; }

    public int? BrTrenutnihKlijenata { get; set; }

    public string? ZoomMeetingLink { get; set; }

    public virtual Korisnici User { get; set; } = null!;

    public virtual ICollection<Klijent> Clients { get; set; } = new List<Klijent>();
}
