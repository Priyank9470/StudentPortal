using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentPortal.Models
{
    public class Pager
    {
        public int TotalData { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPage { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }

        public Pager() { }
        public Pager(int totalData, int page, int pageSize)
        {
            int totalPages = (int)Math.Ceiling((decimal)totalData / (decimal)pageSize);
            int currentPage = page;

            int startPage = currentPage - 2;
            int endPage = currentPage + 2;

            if (startPage <= 0)
            {
                endPage = endPage - (startPage - 1);
                startPage = 1;
            }
            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }

            TotalData = totalData;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPage = totalPages;
            StartPage = startPage;
            EndPage = endPage;
        }
    }
}