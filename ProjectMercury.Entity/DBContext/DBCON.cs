namespace ProjectMercury.Entity.DBContext
{
    using ProjectMercury.Entity.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DBCON : DbContext
    {
        public DBCON()
            : base("name=DBCON")
        {
            Database.SetInitializer(new DBCONInitializer()); // Bu Kod Otomatik database Olu�turma Otomasyonu
        }
        public virtual DbSet<AltKategori> AltKategori { get; set; }
        public virtual DbSet<Kategori> Kategori { get; set; }
        public virtual DbSet<Kullanicilar> Kullanicilar { get; set; }
        public virtual DbSet<Marka> Marka { get; set; }
        public virtual DbSet<Sepet> Sepet { get; set; }
        public virtual DbSet<Siparis> Siparis { get; set; }
        public virtual DbSet<SiteBilgileri> SiteBilgileri { get; set; }
        public virtual DbSet<Slider> Slider { get; set; }
        public virtual DbSet<Urun> Urun { get; set; }
        public virtual DbSet<UrunKategori> UrunKategori { get; set; }
        public virtual DbSet<Uyeler> Uyeler { get; set; }
        public virtual DbSet<Satis> Satis { get; set; }
        public virtual DbSet<UrunSepet> UrunSepet { get; set; }
        public virtual DbSet<SanalSepet> SanalSepet { get; set; }
    }
    public class DBCONInitializer : CreateDatabaseIfNotExists<DBCON> //Otomatik database Olu�turma
    {
        protected override void Seed(DBCON db)
        {
            db.Kategori.Add(new Kategori
            {
                KategoriAdi = "Likit"
            });
            db.SaveChanges();

            db.AltKategori.Add(new AltKategori
            {
                AltKategoriAdi = "D�nyan�n En �yileri",
                KategoriID= 1
            });
            db.SaveChanges();

            db.UrunKategori.Add(new UrunKategori
            {
                UrunKategoriAdi = "�r�n Kategori Yok"
            });
            db.SaveChanges();

            db.UrunKategori.Add(new UrunKategori
            {
                UrunKategoriAdi = "N�KOT�N SEV�YES� 5MG"
            });
            db.SaveChanges();

            db.Marka.Add(new Marka
            {
                MarkaAdi= "Hanging Gardens"
            });
            db.SaveChanges();

            db.Urun.Add(new Urun
            {
                AltKategoriID = 1,
                IndirimliFiyati = "49,90",
                IndirimVarmi = true,
                KategoriID = 1,
                MarkaID=1,
                UrunAciklama= "Ingiliz men�eili 7Wonders markas�n�n Hanging Gardens of Babylon adl� likitidir. Beklentilerin �ok �zerinde bir meyve deneyimi! Orman meyveleri, tropikal meyveler, b���rtlen ve �ile�in en taze hali, limonatan�n ferahl��� ile bulu�tu! Farkl� ve ferah bir meyve deneyimi sizi bekliyor. Likitler %75 VG %25 PG de�erlerine sahiptir.",
                UrunAdedi=1,
                UrunAdi= "Hanging Gardens of Babylon 30ML",
                UrunFiyati= "69,90",
                UrunKategoriID=2,
                Image= "/images/ImageStore/Demo.JPG"
            });
            db.SaveChanges();

            db.Kullanicilar.Add(new Kullanicilar
            {
                KullaniciAdi="admin",
                KullaniciSifre="9916",
                Master=true,
                System=true
            });
            db.SaveChanges();
            db.Kullanicilar.Add(new Kullanicilar
            {
                KullaniciAdi = "demo",
                KullaniciSifre = "1234",
                Master = true,
                System = false
            });
            db.SaveChanges();
            db.Uyeler.Add(new Uyeler
            {
                Sifre = "1234",
                Adres="Kar��yaka �zmir",
                Banlimi=false,
                MailAdresi="seckinumur@gmail.com",
                Tarih=DateTime.Now.ToShortDateString(),
                Telefon="+905423428009",
                UyeAdiSoyadi="Se�kin Umur"
            });
            db.SaveChanges();

            db.SiteBilgileri.Add(new SiteBilgileri()
            {
                Adres = "Kar��yaka/�ZM�R",
                Facebook= "https://www.facebook.com/seckinumur85",
                Instagram="#",
                Telefon="#",
                MailAdresi= "mailto:seckinumur@gmail.com",
                MobilTelefon= "tel:+905423428009",
                SiteAdi= "whitesteam",
                Twitter= "https://twitter.com/SeckinUmur",
                Whatsapp="+905423428009",
                Logo= "/images/Company/projectmercury.PNG"
            });
            db.SaveChanges();

            db.Slider.Add(new Slider()
            {
                Image = "/images/Company/Slider/Slider1.JPG"
            });
            db.SaveChanges();
        }
    }
}