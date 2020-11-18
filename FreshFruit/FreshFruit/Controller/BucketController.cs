using FreshFruit.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;
using FreshFruit.Model;
using System.Linq;

namespace FreshFruit.Controller
{
    class BucketController
    {
        private Bucket bucket;
        private BucketEventListener eventListener;

        public BucketController(Bucket bucket, BucketEventListener eventListener)
        {
            this.bucket = bucket;
            this.eventListener = eventListener;
        }
        public void addFruit(Fruit fruit)
        {
            if (bucketIsOverload())
            {
                eventListener.onFailed("Ops, Maaf Keranjang Sudah Penuh");
            }
            else
            {
                this.bucket.insert(fruit);
                eventListener.onSucceed("Ah Mantap, Buah Berhasil Ditambahkan");

            }
        }
        public bool bucketIsOverload()
        {
            return bucket.countItems() >= bucket.getCapacity();
        }
        public void removeFruit(Fruit fruit)
        {
            for (int itemPosition = 0; itemPosition < bucket.countItems(); itemPosition++)
            {
                if (bucket.findAll().ElementAt(itemPosition).getName() == fruit.getName())
                {
                    bucket.remove(itemPosition);
                    eventListener.onSucceed("Berhasil dihapus");
                }
            }
        }
        public List<Fruit> findAll()
        {
            return this.bucket.findAll();
        }
    }
}