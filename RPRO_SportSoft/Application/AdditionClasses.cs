﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPRO_SportSoft.Application
{
    public class AdditionClasses
    {
    }
}

public class CourtListP
{
   
    public IEnumerable<RPRO_SportSoft.Court> list;
    public String sportText;
    public int sport;
    public CourtListP(int s, String sT, IEnumerable<RPRO_SportSoft.Court> l)
    {
        this.sportText = sT;
        this.list = l;
        this.sport = s;
    }
}