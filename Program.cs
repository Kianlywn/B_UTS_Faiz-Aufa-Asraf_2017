using System;
using System.Collections.Generic;

namespace PerpustakaanApp
{
    public class Book
    {
        public int ID;
        public string Judul;
        public string Penulis;
        public int TahunTerbit;
        public string Status;

        public virtual void TampilkanInfo()
        {
            Console.WriteLine("ID: " + ID);
            Console.WriteLine("Judul: " + Judul);
            Console.WriteLine("Penulis: " + Penulis);
            Console.WriteLine("Tahun Terbit: " + TahunTerbit);
            Console.WriteLine("Status: " + Status);
            Console.WriteLine("-------------------------");
        }
    }

    // Inheritance: ReferenceBook turunan dari Book
    public class ReferenceBook : Book
    {
        public string Kategori;

        public override void TampilkanInfo()
        {
            base.TampilkanInfo();
            Console.WriteLine("Kategori: " + Kategori);
            Console.WriteLine("-------------------------");
        }
    }

    public class Library
    {
        public string Nama;
        public string Alamat;
        public List<Book> KoleksiBuku;

        public Library(string nama, string alamat)
        {
            Nama = nama;
            Alamat = alamat;
            KoleksiBuku = new List<Book>();
        }

        public void TambahBuku(Book buku)
        {
            KoleksiBuku.Add(buku);
            Console.WriteLine("Buku berhasil ditambahkan.");
        }

        public void TampilkanSemuaBuku()
        {
            if (KoleksiBuku.Count == 0)
            {
                Console.WriteLine("Belum ada buku.");
            }
            else
            {
                for (int i = 0; i < KoleksiBuku.Count; i++)
                {
                    KoleksiBuku[i].TampilkanInfo();
                }
            }
        }

        public void CariBuku(string keyword)
        {
            bool ditemukan = false;
            for (int i = 0; i < KoleksiBuku.Count; i++)
            {
                if (KoleksiBuku[i].Judul.ToLower().Contains(keyword.ToLower()) || KoleksiBuku[i].ID.ToString() == keyword)
                {
                    KoleksiBuku[i].TampilkanInfo();
                    ditemukan = true;
                }
            }

            if (!ditemukan)
            {
                Console.WriteLine("Buku tidak ditemukan.");
            }
        }

        public void UpdateBuku(int id)
        {
            bool ditemukan = false;
            for (int i = 0; i < KoleksiBuku.Count; i++)
            {
                if (KoleksiBuku[i].ID == id)
                {
                    Console.Write("Judul baru: ");
                    KoleksiBuku[i].Judul = Console.ReadLine();
                    Console.Write("Penulis baru: ");
                    KoleksiBuku[i].Penulis = Console.ReadLine();
                    Console.Write("Tahun Terbit baru: ");
                    KoleksiBuku[i].TahunTerbit = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Status baru (Tersedia/Dipinjam): ");
                    KoleksiBuku[i].Status = Console.ReadLine();
                    Console.WriteLine("Data buku diperbarui.");
                    ditemukan = true;
                    break;
                }
            }

            if (!ditemukan)
            {
                Console.WriteLine("Buku tidak ditemukan.");
            }
        }

        public void HapusBuku(int id)
        {
            bool ditemukan = false;
            for (int i = 0; i < KoleksiBuku.Count; i++)
            {
                if (KoleksiBuku[i].ID == id)
                {
                    KoleksiBuku.RemoveAt(i);
                    Console.WriteLine("Buku berhasil dihapus.");
                    ditemukan = true;
                    break;
                }
            }

            if (!ditemukan)
            {
                Console.WriteLine("Buku tidak ditemukan.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Library perpustakaan = new Library("Perpustakaan Faiz", "Jl. Contoh No. 1");

            bool jalan = true;
            while (jalan)
            {
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1. Tambah Buku");
                Console.WriteLine("2. Tampilkan Semua Buku");
                Console.WriteLine("3. Cari Buku");
                Console.WriteLine("4. Update Buku");
                Console.WriteLine("5. Hapus Buku");
                Console.WriteLine("6. Keluar");
                Console.Write("Pilih (1-6): ");
                string pilihan = Console.ReadLine();

                if (pilihan == "1")
                {
                    Book bukuBaru = new Book();

                    Console.Write("ID: ");
                    bukuBaru.ID = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Judul: ");
                    bukuBaru.Judul = Console.ReadLine();

                    Console.Write("Penulis: ");
                    bukuBaru.Penulis = Console.ReadLine();

                    Console.Write("Tahun Terbit: ");
                    bukuBaru.TahunTerbit = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Status (Tersedia/Dipinjam): ");
                    bukuBaru.Status = Console.ReadLine();

                    perpustakaan.TambahBuku(bukuBaru);
                }
                else if (pilihan == "2")
                {
                    perpustakaan.TampilkanSemuaBuku();
                }
                else if (pilihan == "3")
                {
                    Console.Write("Masukkan ID atau Judul buku: ");
                    string keyword = Console.ReadLine();
                    perpustakaan.CariBuku(keyword);
                }
                else if (pilihan == "4")
                {
                    Console.Write("Masukkan ID buku yang ingin diperbarui: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    perpustakaan.UpdateBuku(id);
                }
                else if (pilihan == "5")
                {
                    Console.Write("Masukkan ID buku yang ingin dihapus: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    perpustakaan.HapusBuku(id);
                }
                else if (pilihan == "6")
                {
                    Console.WriteLine("Terima kasih telah menggunakan aplikasi.");
                    jalan = false;
                }
                else
                {
                    Console.WriteLine("Pilihan tidak valid.");
                }
            }
        }
    }
}
