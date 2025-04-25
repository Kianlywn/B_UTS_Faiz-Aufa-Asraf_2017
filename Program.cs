using System;

namespace PerpustakaanWibu
{
    // Kelas dasar Book
    public class Book
    {
        public int ID { get; set; }
        public string Judul { get; set; }
        public string Penulis { get; set; }
        public int TahunTerbit { get; set; }
        public string Status { get; set; }

        public virtual void TampilkanInfo()
        {
            Console.WriteLine($"ID: {ID}, Judul: {Judul}, Penulis: {Penulis}, Tahun: {TahunTerbit}, Status: {Status}");
        }
    }

    // Inheritance
    public class ReferenceBook : Book
    {
        public string Kategori { get; set; }

        public override void TampilkanInfo()
        {
            base.TampilkanInfo();
            Console.WriteLine($"Kategori Referensi: {Kategori}");
        }
    }

    // Kelas Library
    public class Library
    {
        public string Nama { get; set; }
        public string Alamat { get; set; }
        private List<Book> koleksiBuku = new List<Book>();

        public Library(string nama, string alamat)
        {
            Nama = nama;
            Alamat = alamat;
        }

        // CREATE
        public void TambahBuku(Book buku)
        {
            koleksiBuku.Add(buku);
            Console.WriteLine("Buku berhasil ditambahkan.\n");
        }

        //READ
        //public void TampilkanSemuaBuku()
        //{
        //    if (koleksiBuku.Count == 0)
        //    {
        //        Console.WriteLine("Tidak ada buku di perpustakaan.");
        //        return;
        //    }

        //    else
        //}

        // UPDATE
        //public void UpdateBuku(int id, string judulBaru, string penulisBaru, int tahunBaru, string statusBaru)
        //{
        //    if (buku != null);
        //    {
        //        Console.WriteLine("Buku Berhasil di update")
        //    }


        //    else
        //    {
        //        Console.WriteLine("Buku Tidak ada. \n");
        //    }
        //}

        // DELETE
        public void HapusBuku(int id)
        {
            //if (buku != null)
            //{
            //    Console.WriteLine("Buku berhasil dihapus.\n");
            //}
            //else
            //{
            //    Console.WriteLine("Buku tidak ada.\n");
            //}
        }
    }

    // Program utama
    class Program
    {
        static void Main(string[] args)
        {
            Library perpustakaan = new Library("Perpustakaan Jago", "Jl. SukaSuka No. 108");

            while (true)
            {
                Console.WriteLine("\n=== MENU PERPUSTAKAAN ===");
                Console.WriteLine("1. Tambah Buku");
                Console.WriteLine("2. Tampilkan Semua Buku");
                Console.WriteLine("3. Update Buku");
                Console.WriteLine("4. Hapus Buku");
                Console.WriteLine("5. Keluar");
                Console.Write("Pilih menu (1-5): ");
                string pilihan = Console.ReadLine();

                //if (pilihan = "1")
                //{

                //}
                
            }
        }
    }
}

