using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikasiInputdataMahasiswa
{
    public partial class Form1 : Form
    {
        private void InisialisasiListView()
        {
            lstMahasiswa.View = View.Details;
            lstMahasiswa.FullRowSelect = true;
            lstMahasiswa.GridLines = true;

            lstMahasiswa.Columns.Add("No.", 30, HorizontalAlignment.Center);
            lstMahasiswa.Columns.Add("NIM", 70, HorizontalAlignment.Center);
            lstMahasiswa.Columns.Add("NAMA", 150, HorizontalAlignment.Center);
            lstMahasiswa.Columns.Add("KELAS", 50, HorizontalAlignment.Center);
            lstMahasiswa.Columns.Add("NILAI", 40, HorizontalAlignment.Center);
            lstMahasiswa.Columns.Add("HURUF", 50, HorizontalAlignment.Center);
        }
        private void ResetForm()
        {
            txtNim.Clear();
            txtNama.Clear();
            txtKelas.Clear();
            txtNilai.Text = "0";
            txtNim.Focus();
        }
        private bool NumericOnly(KeyPressEventArgs e)
        {
            var strValid = "0123456789";
            if (!(e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                if (strValid.IndexOf(e.KeyChar) < 0)
                {
                    return true;
                }
                return false;
            }
            else
                return false;
        }

        private void TampilkanData()
        {
            lstMahasiswa.Items.Clear();
            foreach (var mhs in list)
            {
                var noUrut = lstMahasiswa.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(mhs.Nim);
                item.SubItems.Add(mhs.Nama);
                item.SubItems.Add(mhs.Kelas);
                item.SubItems.Add(mhs.Nilai.ToString());
                item.SubItems.Add(mhs.Huruf);

                lstMahasiswa.Items.Add(item);
            }
        }

        private List<Mahasiswa> list = new List<Mahasiswa>();

        public Form1()
        {
            InitializeComponent();
            InisialisasiListView();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lstMahasiswa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void txtNilai_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = NumericOnly(e);
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            Mahasiswa mhs = new Mahasiswa();
            mhs.Nim = txtNim.Text;
            mhs.Nama = txtNama.Text;
            mhs.Kelas = txtKelas.Text;
            mhs.Nilai = int.Parse(txtNilai.Text);

            if (mhs.Nilai <= 20)
            {
                mhs.Huruf = "E";
            } else if (mhs.Nilai <= 40)
            {
                mhs.Huruf = "D";
            }
            else if (mhs.Nilai <= 60)
            {
                mhs.Huruf = "C";
            }
            else if (mhs.Nilai <= 80)
            {
                mhs.Huruf = "B";
            }
            else if (mhs.Nilai <= 100)
            {
                mhs.Huruf = "A";
            }
            else if (mhs.Nilai > 100)
            {
                mhs.Huruf = "-";
            }

            list.Add(mhs);
            var msg = "Data mahasiswa berhasil disimpan.";

            MessageBox.Show(msg, "Informasi", MessageBoxButtons.OK,
            MessageBoxIcon.Information);
            ResetForm();

        }

        private void btnTampilkan_Click(object sender, EventArgs e)
        {
            TampilkanData();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (lstMahasiswa.SelectedItems.Count > 0)
            {
                var konfirmasi = MessageBox.Show("Apakah data mahasiswa ingin dihapus ? ", "Konfirmasi",
               
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (konfirmasi == DialogResult.Yes)
                {
                    var index = lstMahasiswa.SelectedIndices[0];
                    list.RemoveAt(index);
                    TampilkanData();
                }
            }
            else 
            {
                MessageBox.Show("Data mahasiswa belum dipilih !!!", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
