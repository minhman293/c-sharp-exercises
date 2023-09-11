using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BAITAP_KETHUA
{
    class DanhSachNhanVien: BaiTap_HDT_1.IInputOutput
    {
        Dictionary<String, NhanVien> listStaff;
        public DanhSachNhanVien()
        {
            this.listStaff = new Dictionary<string, NhanVien>();
        }

        public void ReadFile()
        {
            String fileName = "D:\\danhsachnhanvien.txt";
            String[] AllLines = File.ReadAllLines(fileName);
            foreach (String line in AllLines)
            {
                String [] info = line.Split(',');
                NhanVien nv = null;
                if (info[0] == "B")
                {
                    nv = new NhanVienBienChe();
                    ((NhanVienBienChe)nv).Hesoluong = double.Parse(info[7]);
                }
                else
                {
                    nv = new NhanVienHopDong();
                    ((NhanVienHopDong)nv).Mucluong = double.Parse(info[7]);
                }
                nv.Manv = info[1];
                nv.Hoten = info[2];
                nv.Gioitinh = info[3];
                nv.Ngaysinh = DateTime.Parse(info[4]);
                nv.Ngayvaocoquan = DateTime.Parse(info[5]);
                nv.Socm = long.Parse(info[6]);
                this.listStaff.Add(nv.Manv, nv);
            }
        }
        public void WriteFile()
        {
            String fileName = "D:\\danhsachnhanvien.txt";
            StreamWriter wr = new StreamWriter(fileName);
            foreach (NhanVien nv in this.listStaff.Values)
            {
                String info = null;
                double hesoluong_mucluong;
                if (nv is NhanVienBienChe)
                {
                    info = "B,";
                    hesoluong_mucluong = ((NhanVienBienChe)nv).Hesoluong;
                }
                else
                {
                    info = "H,";
                    hesoluong_mucluong = ((NhanVienHopDong)nv).Mucluong;
                }
                info += nv.Manv + "," + nv.Hoten + "," + nv.Gioitinh + ","
                    + nv.Ngaysinh.ToString("dd/MM/yyyy") + ","
                    + nv.Ngayvaocoquan.ToString("dd/MM/yyyy") + ","
                    + nv.Socm + "," + hesoluong_mucluong;
                wr.WriteLine(info);
            }
            wr.Close();
        }
        public void Nhap()
        {
            char c = 'y';
            while (c == 'y')
            {
                NhanVien nv = null;
                char loai = ' ';
                Console.WriteLine("nhap (B) cho bien che, (H) cho hop dong");
                loai = char.Parse(Console.ReadLine().ToUpper());
                if (loai == 'B')
                {
                    nv = new NhanVienBienChe();
                    nv.Nhap();
                }
                else if (loai == 'H')
                {
                    nv = new NhanVienHopDong();
                    nv.Nhap();
                }
                if (nv != null)
                    this.listStaff.Add(nv.Manv, nv);
                Console.WriteLine("nhan (y) de tiep tuc");
                c = char.Parse(Console.ReadLine().ToLower());
            }
        }
        public void Xuat()
        {
            Console.WriteLine("ma nhan vien | ho ten | ngay sinh | gioi tinh | so cm | phu cap | thuc linh");
            foreach (NhanVien nv in listStaff.Values)
                Console.WriteLine("{0, 2} {1, 10} {2, 20}", nv.Manv, nv.Hoten, nv.Ngaysinh.ToString("dd/MM/yyyy"));
        }
        public NhanVien Tim()
        {
            Console.WriteLine("nhap ma nhan vien can tim: ");
            String manv = Console.ReadLine();
            return this.listStaff[manv];
        }
        public void Xoa()
        {
            Console.WriteLine("nhap ma nhan vien can xoa: ");
            String manv = Console.ReadLine();
            this.listStaff.Remove(manv);
        }
        public void ThongKe()
        {
            int tongbienche = 0;
            int tonghopdong = 0;

            foreach (NhanVien nv in this.listStaff.Values)
                if (nv is NhanVienBienChe)
                    tongbienche++;
                else if (nv is NhanVienHopDong)
                    tonghopdong++;

            Console.WriteLine("tong so nhan vien bien che: " + tongbienche);
            Console.WriteLine("tong so nhan vien hop dong: " + tonghopdong);
        }
        public void TongLuong()
        {
            double tongluong = 0;
            foreach (NhanVien nv in this.listStaff.Values)
                tongluong += nv.tinhThucLinh();
            Console.WriteLine("tong quy luong: " + tongluong);
        }

    }
}
