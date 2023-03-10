using BusinessObject.Repository;
using DataAccess;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesWinApp
{
    public partial class frmMembers : Form
    {
        private IMemberRepository memberRepository = new MemberRepository();
        private List<Member> members;
        private bool updateMode = false;
        private frmMain frmMain;

        public frmMembers(frmMain frmMain)
        {
            InitializeComponent();
            members = memberRepository.GetAllMember();
            dgv_members.DataSource = members;
            btn_Update.Enabled = false;
            btn_Delete.Enabled = false;
            this.frmMain = frmMain;
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //take the chosen index
            int index = dgv_members.SelectedCells[0].RowIndex;
            //get get member
            Member member = members[index];
            //start update mode
            EnableUpdateMode(member);
        }

        private void EnableUpdateMode(Member member)
        {
            updateMode = true;
            tbx_City.Text = member.City;
            tbx_CompanyName.Text = member.CompanyName;
            tbx_Country.Text = member.Country;
            tbx_Email.Text = member.Email;
            tbx_UserId.Text = member.MemberId.ToString();
            tbx_UserId.Enabled = false;
            mtbx_Password.Text = "";
            mtbx_RepeatPassword.Text = "";

            lbl_PasswordTip.Visible = true;

            btn_Update.Enabled = true;
            btn_Delete.Enabled = true;

        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            //clean up if updating
            if (updateMode)
            {
                updateMode = false;
                tbx_City.Text = "";
                tbx_CompanyName.Text = "";
                tbx_Country.Text = "";
                tbx_Email.Text = "";
                tbx_UserId.Text = "";
                tbx_UserId.Enabled = true;
                mtbx_Password.Text = "";
                mtbx_RepeatPassword.Text = "";

                lbl_PasswordTip.Visible = false;

                btn_Update.Enabled = false;
                btn_Delete.Enabled = false;
            }


            else


            {
                try
                {
                    //member object for checking if member already exists
                    Member member;

                    //user id must be valid
                    int userId;
                    if (!int.TryParse(tbx_UserId.Text, out userId))
                    {
                        throw new Exception("Invalid user id");
                    }

                    //user email must be filled
                    if (tbx_Email.Text == "")
                    {
                        throw new Exception("Email must not be left empty");
                    }

                    //member id must not exists
                    member = memberRepository.getMemberById(userId);
                    if (member != null)
                    {
                        throw new Exception("user id is already used");
                    }

                    //member email must not being used
                    member = memberRepository.getMemberByEmail(tbx_Email.Text);
                    if (member != null)
                    {
                        throw new Exception("user email is already used");
                    }

                    //password must not be empty
                    if (mtbx_Password.Text == "" || mtbx_RepeatPassword.Text == "")
                    {
                        throw new Exception("Password must be filled");
                    }

                    //password and repeat password must match
                    if (!mtbx_Password.Text.Equals(mtbx_RepeatPassword.Text))
                    {
                        throw new Exception("Password does not match");
                    }

                    member = new Member();
                    member.MemberId = userId;
                    member.Email = tbx_Email.Text;
                    member.City = tbx_City.Text;
                    member.CompanyName = tbx_CompanyName.Text;
                    member.Password = mtbx_Password.Text;
                    member.Country = tbx_Country.Text;
                    Debug.WriteLine("frmMembers:btn_New_Click: Adding a new member into db");

                    memberRepository.AddMember(member);
                    MessageBox.Show("New User has been added successfully");


                    members.Insert(0, member);
                    dgv_members.DataSource = members;
                    dgv_members.Rows.Clear();
                    members = memberRepository.GetAllMember();
                    dgv_members.DataSource = members;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An Error has occured while adding new member: " + ex);
                }
            }



        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                //member object for checking if member already exists
                Member member;

                //user id must be valid
                int userId;
                if (!int.TryParse(tbx_UserId.Text, out userId))
                {
                    throw new Exception("Invalid user id");
                }

                //user email must be filled
                if (tbx_Email.Text == "")
                {
                    throw new Exception("Email must not be left empty");
                }

                //member id must not exists
                member = memberRepository.getMemberById(userId);
                if (member == null)
                {
                    throw new Exception("user id is not used");
                }

                //member email must not being used
                member = memberRepository.getMemberByEmail(tbx_Email.Text);
                if (member != null && (member.Email.ToString() != tbx_Email.Text))
                {
                    throw new Exception("user email is already used");
                }

                //password and repeat password must match
                if (!mtbx_Password.Text.Equals(mtbx_RepeatPassword.Text))
                {
                    throw new Exception("Password does not match");
                }

                member = new Member();
                member.MemberId = userId;
                member.Email = tbx_Email.Text;
                member.City = tbx_City.Text;
                member.CompanyName = tbx_CompanyName.Text;

                if (mtbx_Password.Text == "")
                {
                    member.Password = memberRepository.getMemberById(userId).Password;
                }
                else
                {
                    member.Password = mtbx_Password.Text;
                }

                member.Country = tbx_Country.Text;
                Debug.WriteLine("frmMembers:btn_New_Click: Updating a member");

                memberRepository.UpdateMember(member);
                MessageBox.Show("User has been updated successfully");


                members.Insert(0, member);
                dgv_members.DataSource = members;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error has occured while adding new member: " + ex);
            }
        }

        private void btn_GoBack_Click(object sender, EventArgs e)
        {
            frmMain.Show();
            this.Close();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            if (tbx_search.Text == "")
            {
                members = memberRepository.GetAllMember();
            }
            members = memberRepository.SearchMember(tbx_search.Text);
            dgv_members.DataSource = members;
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            //show yes/no box
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this record ?", "Delete Confirmation"
                , MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Member member = new Member();
                member.MemberId = int.Parse(tbx_UserId.Text);
                memberRepository.RemoveMember(member);

                //reload dgv
                members = memberRepository.GetAllMember();
                dgv_members.DataSource = members;
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }
    }
}
