using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TPP_Project.Models
{
    public enum TaskStatus { Initial, InProgress, OnHold, Completed};
    public enum ProjectStatus { Initial, InProgress, OnHold, Completed};
    public enum OrderStatus { Initiating, Processiong,Canceled,Rejected, Completed};
    public enum TemplateSiteTypes { Blog, VisitCard, Oficial, Shop, Amazing };
}
