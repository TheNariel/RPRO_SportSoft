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
public class SportB
{
    public Boolean boo;
    public String sport;
    public SportB(String s, Boolean b)
    {
        this.boo = b;
        this.sport = s;
    }
}
public class CourtB
{
    public Boolean boo;
    public String court;
    public int sport;
    public CourtB(String c,int s, Boolean b)
    {
        this.boo = b;
        this.sport = s;
        this.court = c;
    }
}
public class CourtListP
{
   
    public IEnumerable<RPRO_SportSoft.Court> list;
    public int sport;
    public CourtListP(int s, IEnumerable<RPRO_SportSoft.Court> l)
    {
        this.list = l;
        this.sport = s;
    }
}