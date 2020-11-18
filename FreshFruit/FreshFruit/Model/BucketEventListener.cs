using System;
using System.Collections.Generic;
using System.Text;

namespace FreshFruit.Model
{
    interface BucketEventListener
    {
        void onSucceed(string massage);
        void onFailed(string massage);
    }
}