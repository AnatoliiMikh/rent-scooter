﻿namespace RentScooter.Context.Entities;
public class Period
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public Report Report { get; set; }
}