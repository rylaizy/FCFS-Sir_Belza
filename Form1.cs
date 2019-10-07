using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hangover
{
    public partial class Form1 : Form
    {
        List<Label> labels;
        List<TextBox> textboxes;
        public Form1()
        {
            InitializeComponent();
            
            //Control[] controls = { lblPA,lblPB,};
            labels = new List<Label> {lbl1, lbl2, lbl3 };
            textboxes = new List<TextBox>{ txt1, txt2, txt3 };
        }
        
        List<int> nums = new List<int>();
        String process = "";
        int tempAT=0, tempBT=0,currAT= 0,currBT=0;
        private void btnCompute_Click(object sender, EventArgs e)
        {
            int[] pa = { int.Parse(txtPA_AT.Text), int.Parse(txtPA_BT.Text) };
            int[] pb = { int.Parse(txtPB_AT.Text), int.Parse(txtPB_BT.Text) };
            int[] pc = { int.Parse(txtPC_AT.Text), int.Parse(txtPC_BT.Text) };
            insertToList(pa);
            insertToList(pb);
            insertToList(pc);
            nums.Sort();
            lblLowest.Text = nums[0].ToString();
            compareArrays(pa, pb, pc);
        }

        public void compareArrays(int[]pa,int[]pb,int[]pc)
        {
            List<String> processes = new List<String> { "PA", "PB", "PC" };
            while (processes.Count>0){
                //Arrival Time
                if (processes.Contains("PA")) {
                    if (pa[0] < pb[0] && pa[0] < pc[0])
                    {//PA yung tama
                        MessageBox.Show("PA");
                        process = processes[0];
                        processes.RemoveAt(0);

                        currAT = pa[0];
                        currBT = pa[1] + tempBT;
                        for (int i = 0; i < 2; i++)
                        {
                            if(labels[i].Text != "")
                            {
                                labels[i].Text = currBT.ToString();
                            }
                        }
                        tempBT = currBT;
                        //TextBox
                        for (int i = 0; i < 2; i++) {
                            if (textboxes[i].Text != "")
                            {
                                textboxes[i].Text =process;
                            }
                        }
                        tempAT = currAT;
                    }
                }else if (processes.Contains("PB"))
                {
                    if (pb[0] < pa[0] && pb[0] < pc[0])
                    {//PB tama
                        MessageBox.Show("PB");
                        process = processes[1];
                        processes.RemoveAt(1);
                        currAT = pb[0];
                        currBT = pb[1] + tempBT;
                        for (int i = 0; i < 2; i++)
                        {
                            if (labels[i].Text != "")
                            {
                                labels[i].Text = currBT.ToString();
                            }
                        }
                        tempBT = currBT;
                        txt1.Text = processes[1];
                        tempAT = currAT;
                    }
                }else if (processes.Contains("PC"))
                {
                    MessageBox.Show("PC");
                    if (pc[0] < pa[0] && pc[0] < pb[0])
                    {//PC tama
                        process = processes[2];
                        processes.RemoveAt(2);
                        currAT = pc[0];
                        currBT = pc[1] + tempBT;
                        for (int i = 0; i < 2; i++)
                        {
                            if (labels[i].Text != "")
                            {
                                labels[i].Text = currBT.ToString();
                            }
                        }
                        tempBT = currBT;
                        txt3.Text = processes[2];
                        tempAT = currAT;
                    }
                }
                else
                {
                    MessageBox.Show("Paalam kapatid");
                }
            }
        }

        public void insertToList(int[] x)
        {
            for (int i = 0; i < x.Length; i++)
            {
                nums.Add(x[i]);
                Console.WriteLine(x[i] + "Added to list");
            }
        }

        
    }
}
