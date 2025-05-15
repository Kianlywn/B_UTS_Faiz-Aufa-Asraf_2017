using System;
using System.Collections.Generic;
using System.Linq;

namespace Nigger
{
    public class Book
    {
        public int ID { get; set; }
        public string Judul { get; set; }
        public string Penulis { get; set; }
        public int TahunTerbit { get; set; }
        public bool Status { get; set; } // true = tersedia, false = dipinjam

        public Book(int id, string judul, string penulis, int tahunTerbit)
        {
            ID = id;
            Judul = judul;
            Penulis = penulis;
            TahunTerbit = tahunTerbit;
            Status = true;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"Judul: {Judul}");
            Console.WriteLine($"Penulis: {Penulis}");
            Console.WriteLine($"Tahun Terbit: {TahunTerbit}");
            Console.WriteLine($"Status: {(Status ? "Tersedia" : "Dipinjam")}");
            Console.WriteLine("-----------------------------");
        }
    }

    public class ReferenceBook : Book
    {
        public string Kategori { get; set; }

        public ReferenceBook(int id, string judul, string penulis, int tahunTerbit, string kategori)
            : base(id, judul, penulis, tahunTerbit)
        {
            Kategori = kategori;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Kategori: {Kategori}");
            Console.WriteLine("-----------------------------");
        }
    }

    public class Perpustakaan
    {
        public string Nama { get; set; }
        public string Alamat { get; set; }
        private List<Book> KoleksiBuku { get; set; }

        public Perpustakaan(string nama, string alamat)
        {
            Nama = nama;
            Alamat = alamat;
            KoleksiBuku = new List<Book>();
        }

        public void TambahBuku(Book buku)
        {
            KoleksiBuku.Add(buku);
            Console.WriteLine("Buku berhasil ditambahkan!");
        }

        public void TampilkanSemuaBuku()
        {
            if (KoleksiBuku.Count == 0)
            {
                Console.WriteLine("Tidak ada buku dalam koleksi.");
                return;
            }

            Console.WriteLine($"\nDaftar Buku di {Nama}:");
            for (int i = 0; i < KoleksiBuku.Count; i++)
            {
                KoleksiBuku[i].DisplayInfo();
            }
        }

        public Book CariBukuByID(int id)
        {
            foreach (Book buku in KoleksiBuku)
            {
                if (buku.ID == id)
                {
                    return buku;
                }
            }
            return null;
        }

        public List<Book> CariBukuByJudul(string judul)
        {
            List<Book> hasilPencarian = new List<Book>();
            foreach (Book buku in KoleksiBuku)
            {
                if (buku.Judul.ToLower().Contains(judul.ToLower()))
                {
                    hasilPencarian.Add(buku);
                }
            }
            return hasilPencarian;
        }

        public bool UpdateBuku(int id, string judul, string penulis, int tahunTerbit, bool status)
        {
            Book buku = CariBukuByID(id);
            if (buku != null)
            {
                buku.Judul = judul;
                buku.Penulis = penulis;
                buku.TahunTerbit = tahunTerbit;
                buku.Status = status;
                return true;
            }
            return false;
        }

        public bool HapusBuku(int id)
        {
            Book buku = CariBukuByID(id);
            if (buku != null)
            {
                KoleksiBuku.Remove(buku);
                return true;
            }
            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Perpustakaan perpustakaan = new Perpustakaan("Perpustakaan Kota", "Jl. Merdeka No. 1");

            perpustakaan.TambahBuku(new Book(1, "Debat Montelli Fisalia", "Si Karbit", 2025));
            perpustakaan.TambahBuku(new Book(2, "Pembungkaman 2025", "Abdul Kareem", 2025));
            perpustakaan.TambahBuku(new ReferenceBook(3, "Sejarah RRQ", "Kingdom", 2025, "Kamus"));

            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("\nSistem Manajemen Perpustakaan");
                Console.WriteLine("1. Tambah Buku");
                Console.WriteLine("2. Tampilkan Semua Buku");
                Console.WriteLine("3. Cari Buku");
                Console.WriteLine("4. Update Buku");
                Console.WriteLine("5. Hapus Buku");
                Console.WriteLine("6. Keluar");
                Console.Write("Pilih menu: ");

                string pilihan = Console.ReadLine();

                if (pilihan == "1")
                {
                    Console.WriteLine("\nTambah Buku Baru");
                    Console.Write("Masukkan ID: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Masukkan Judul: ");
                    string judul = Console.ReadLine();
                    Console.Write("Masukkan Penulis: ");
                    string penulis = Console.ReadLine();
                    Console.Write("Masukkan Tahun Terbit: ");
                    int tahun = int.Parse(Console.ReadLine());

                    Console.Write("Apakah buku referensi? (y/n): ");
                    if (Console.ReadLine().ToLower() == "y")
                    {
                        Console.Write("Masukkan Kategori: ");
                        string kategori = Console.ReadLine();
                        perpustakaan.TambahBuku(new ReferenceBook(id, judul, penulis, tahun, kategori));
                    }
                    else
                    {
                        perpustakaan.TambahBuku(new Book(id, judul, penulis, tahun));
                    }
                }
                else if (pilihan == "2")
                {
                    perpustakaan.TampilkanSemuaBuku();
                }
                else if (pilihan == "3")
                {
                    Console.WriteLine("\nCari Buku");
                    Console.WriteLine("1. Cari berdasarkan ID");
                    Console.WriteLine("2. Cari berdasarkan Judul");
                    Console.Write("Pilih: ");
                    string pilihanCari = Console.ReadLine();

                    if (pilihanCari == "1")
                    {
                        Console.Write("Masukkan ID: ");
                        int cariId = int.Parse(Console.ReadLine());
                        Book buku = perpustakaan.CariBukuByID(cariId);
                        if (buku != null)
                        {
                            Console.WriteLine("\nHasil Pencarian:");
                            buku.DisplayInfo();
                        }
                        else
                        {
                            Console.WriteLine("Buku tidak ditemukan.");
                        }
                    }
                    else if (pilihanCari == "2")
                    {
                        Console.Write("Masukkan Judul: ");
                        string cariJudul = Console.ReadLine();
                        List<Book> hasil = perpustakaan.CariBukuByJudul(cariJudul);
                        if (hasil.Count > 0)
                        {
                            Console.WriteLine("\nHasil Pencarian:");
                            for (int i = 0; i < hasil.Count; i++)
                            {
                                hasil[i].DisplayInfo();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Buku tidak ditemukan.");
                        }
                    }
                }
                else if (pilihan == "4")
                {
                    Console.WriteLine("\nUpdate Buku");
                    Console.Write("Masukkan ID buku yang akan diupdate: ");
                    int updateId = int.Parse(Console.ReadLine());
                    Book bukuToUpdate = perpustakaan.CariBukuByID(updateId);
                    if (bukuToUpdate != null)
                    {
                        Console.Write("Masukkan Judul baru: ");
                        string newJudul = Console.ReadLine();
                        Console.Write("Masukkan Penulis baru: ");
                        string newPenulis = Console.ReadLine();
                        Console.Write("Masukkan Tahun Terbit baru: ");
                        int newTahun = int.Parse(Console.ReadLine());
                        Console.Write("Masukkan Status (1=Tersedia, 0=Dipinjam): ");
                        bool newStatus = Console.ReadLine() == "1";

                        if (perpustakaan.UpdateBuku(updateId, newJudul, newPenulis, newTahun, newStatus))
                        {
                            Console.WriteLine("Buku berhasil diupdate!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Buku tidak ditemukan.");
                    }
                }
                else if (pilihan == "5")
                {
                    Console.WriteLine("\nHapus Buku");
                    Console.Write("Masukkan ID buku yang akan dihapus: ");
                    int hapusId = int.Parse(Console.ReadLine());
                    if (perpustakaan.HapusBuku(hapusId))
                    {
                        Console.WriteLine("Buku berhasil dihapus!");
                    }
                    else
                    {
                        Console.WriteLine("Buku tidak ditemukan.");
                    }
                }
                else if (pilihan == "6")
                {
                    isRunning = false;
                }
                else
                {
                    Console.WriteLine("Pilihan tidak valid.");
                }
            }

            Console.WriteLine("Terima kasih telah menggunakan sistem perpustakaan.");
        }
    }
}
