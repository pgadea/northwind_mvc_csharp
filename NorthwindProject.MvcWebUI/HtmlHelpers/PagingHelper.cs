using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using NorthwindProject.MvcWebUI.Models;

namespace NorthwindProject.MvcWebUI.HtmlHelpers
{
    public static class PagingHelper
    {
        public static MvcHtmlString Pager(this HtmlHelper helper, PagingInfo pagingInfo)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append("<ul class='pagination pull-right'>");

            if (pagingInfo.CurrentPage != 1)
            {
                int previous = pagingInfo.CurrentPage - 1;
                stringBuilder.AppendFormat("<li><a href=\"{0}{1}\">&laquo;</a></li>",
                    pagingInfo.BaseUrl, previous);
            }

            for (int i = 1; i <= pagingInfo.TotalPageCount; i++)
            {
                stringBuilder.Append(string.Format("<li class='{2}'><a  href='{1}{0}'>{0}</a></li>", i,
                    pagingInfo.BaseUrl, pagingInfo.CurrentPage == i ? "active" : string.Empty));
            }

            if (pagingInfo.CurrentPage < pagingInfo.TotalPageCount)
            {
                int next = pagingInfo.CurrentPage + 1;
                stringBuilder.AppendFormat("<li><a href=\"{0}{1}\">&raquo;</a></li>",
                    pagingInfo.BaseUrl, next);
            }

            stringBuilder.Append("</ul>");
            return MvcHtmlString.Create(stringBuilder.ToString());
        }
    }
}