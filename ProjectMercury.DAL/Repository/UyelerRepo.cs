﻿using ProjectMercury.DAL.VMModels;
using ProjectMercury.Entity.DBContext;
using ProjectMercury.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMercury.DAL.Repository
{
    public class UyelerRepo
    {
        public static bool UyeKaydet(VMUyeler Al) //Üye Kaydet
        {
            using (DBCON db = new DBCON())
            {
                bool Control = db.Uyeler.Any(p => p.MailAdresi == Al.MailAdresi && p.Sifre == Al.Sifre);
                if (Control != true)
                {
                    db.Uyeler.Add(new Uyeler()
                    {
                        Adres = Al.Adres,
                        MailAdresi = Al.MailAdresi,
                        UyeAdiSoyadi = Al.UyeAdiSoyadi,
                        Sifre = Al.Sifre,
                        Tarih = DateTime.Now.ToShortDateString(),
                        Telefon = Al.Telefon
                    });
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public static bool UyeGuncelle(VMUyeler Al) //Üye Guncelle
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var Bul = db.Uyeler.FirstOrDefault(p => p.UyelerID == Al.UyelerID);

                    Bul.Adres = Al.Adres;
                    Bul.Banlimi = Al.Banlimi;
                    Bul.MailAdresi = Al.MailAdresi;
                    Bul.UyeAdiSoyadi = Al.UyeAdiSoyadi;
                    Bul.Sifre = Al.Sifre;
                    Bul.Telefon = Al.Telefon;
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static bool UyeSil(int ID) //Üye Sil
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var Bul = db.Uyeler.FirstOrDefault(p => p.UyelerID == ID);
                    db.Uyeler.Remove(Bul);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static VMUyeler UyeListele(string ID) //Üye Bul
        {
            int id = int.Parse(ID);
            using (DBCON db = new DBCON())
            {
                return db.Uyeler.Where(p => p.UyelerID == id).Select(p => new VMUyeler
                {
                    Adres = p.Adres,
                    Banlimi = p.Banlimi,
                    MailAdresi = p.MailAdresi,
                    UyeAdiSoyadi = p.UyeAdiSoyadi,
                    Sifre = p.Sifre,
                    Tarih = p.Tarih,
                    Telefon = p.Telefon,
                    UyelerID = p.UyelerID
                }).FirstOrDefault();
            }
        }
        public static string UyeIsmi(string ID) //Üye İsmi Bul
        {
            using (DBCON db = new DBCON())
            {
                int id = int.Parse(ID);
                return db.Uyeler.FirstOrDefault(p => p.UyelerID == id).UyeAdiSoyadi;
            }
        }
        public static List<VMUyeler> TumUyeler() //Üyelerin hepsi
        {
            using (DBCON db = new DBCON())
            {
                return db.Uyeler.Select(p => new VMUyeler
                {
                    Adres = p.Adres,
                    Banlimi = p.Banlimi,
                    MailAdresi = p.MailAdresi,
                    UyeAdiSoyadi = p.UyeAdiSoyadi,
                    Sifre = p.Sifre,
                    Tarih = p.Tarih,
                    Telefon = p.Telefon,
                    UyelerID = p.UyelerID
                }).ToList();
            }
        }
        public static bool UyeBanla(VMUyeler Al) //Üye Banla
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var Bul = db.Uyeler.FirstOrDefault(p => p.UyelerID == Al.UyelerID);
                    Bul.Banlimi = true;
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static bool UyeBanlaKaldir(VMUyeler Al) //Üye BanKaldir
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var Bul = db.Uyeler.FirstOrDefault(p => p.UyelerID == Al.UyelerID);
                    Bul.Banlimi = false;
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static int UyeGirisi(VMLogin Al) //Uye Giriş
        {
            using (DBCON db = new DBCON())
            {
                try
                {
                    var bul = db.Uyeler.FirstOrDefault(p => p.MailAdresi == Al.KullaniciAdi && p.Sifre == Al.KullaniciSifre);
                    return bul.UyelerID;
                }
                catch
                {
                    return 0;
                }
            }
        }
    }
}
