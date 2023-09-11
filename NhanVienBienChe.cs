using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAITAP_KETHUA
{
    class NhanVienBienChe : NhanVien
    {
        private double hesoluong;
        public double Hesoluong
        {
            set { this.hesoluong = value; }
            get { return this.hesoluong; }
        }
        public NhanVienBienChe() : base() { }
        public NhanVienBienChe(string mnv, string ten, string gioi, DateTime dob, DateTime ngayvaocq, long scm, double hesl) : base(mnv, ten, gioi, dob, ngayvaocq, scm)
        {
            this.hesoluong = hesl;
        }
        public override double tinhPhuCap()
        {
            if (base.tinhThamNien() >= 10)
                return base.luongcoban * 0.1 + 500000;
            else
                return base.luongcoban * 0.1 + 200000;
        }
        public override double tinhThucLinh()
        {
            return (base.luongcoban * this.hesoluong) + this.tinhPhuCap();
        }
        public override void Nhap()
        {
            base.Nhap();
            Console.WriteLine("nhap he so luong: ");
            this.hesoluong = double.Parse(Console.ReadLine());
        }
        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine("he so luong: " + this.hesoluong);
            Console.WriteLine("phu cap: " + this.tinhPhuCap());
            Console.WriteLine("thuc linh: " + this.tinhThucLinh());
        }
    }
}
