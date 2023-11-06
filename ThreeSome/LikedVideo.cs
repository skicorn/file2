using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThreeSome.Models;

namespace ThreeSome
{
    public class LikedVideo
    {
        public int userID { get; set; }
        public List<int> VideoLike {  get; set; }
        public void AddLike(int videoId)
        {
            if (VideoLike == null)
            {
                VideoLike = new List<int>();
            }

            VideoLike.Add(videoId);
        }
    }
}