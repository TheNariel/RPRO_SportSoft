using System;
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
    public String sportName;
    public int sportId;
    public CourtListP(int s, String sT, IEnumerable<RPRO_SportSoft.Court> l)
    {
        this.sportName = sT;
        this.list = l;
        this.sportId = s;
    }
}
public static class F
{
    private static int flag;

    public static int Mflag
    {
        get { return flag; }
        set { flag = value; }
    }

}
