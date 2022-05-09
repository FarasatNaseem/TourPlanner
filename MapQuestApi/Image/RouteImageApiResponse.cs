﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapQuestApi.Image
{
    public class RouteImageApiResponse
    {
        public RouteImageApiResponse(string path, bool isFetched)
        {
            this.Path = path;
            this.IsFetched = isFetched;
        }
        public string Path { get; }
        public bool IsFetched { get; }
    }
}
