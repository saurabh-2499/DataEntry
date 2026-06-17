using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Web.UI.WebControls;
using System.Data;
using Npgsql;
using NpgsqlTypes;
 

namespace NIC.WebLMISLibrary
{   
    public class ClsBuyerDetail
    {
        clsCommonFunc func = new clsCommonFunc();
        clsCommonFunction objclscommonfunc = new clsCommonFunction();
        public DataSet funGetBuyerGrid(string DBName, ref GridView gdv, string TableName, string ColValue, string Condition, string Orderby)
        {
            DataBaseHandler handler = new DataBaseHandler(DBName, "LRSRO Connection StringMutation");
            DataSet set = new DataSet();
            string cmdText = "select  " + ColValue + " from " + TableName;
            if (Condition != "")
            {
                cmdText = cmdText + " WHERE " + Condition;
            }
            if (Orderby != "")
            {
                cmdText = cmdText + " Order by " + Orderby;
            }
            DbCommand command = handler.SetCommandText(cmdText, CommandType.Text);
            set = handler.FillDataset(command);
            gdv.DataSource = set.Tables[0].DefaultView;
            gdv.DataBind();
            return set;
        }

        public void funInsertBuyer(string DataBaseName, string SchemaName, string loginid, string ccode, string mutno, DataTable NewVarsTable, DataTable PinTable, string type,string deal_text, ref Label lblMessage)
        {
            DataBaseHandler handler = new DataBaseHandler(DataBaseName, "LRSRO Connection StringMutation");
            string cmdText = "select max(mut_no)+1 from " + SchemaName + ".m_village_census where ccode=@para_ccode";
            DbCommand cmd = handler.SetCommandText(cmdText, CommandType.Text);
            handler.SetInParameter(cmd, "@para_ccode", DbType.String, ccode);
            string str2 = handler.ExecuteScalarstring(cmd);
            if (type == "T")
            {
                mutno = str2;
            }
            else
            {
                str2 = Convert.ToString(mutno);
            }
            
            
                DataBaseHandler handler2 = new DataBaseHandler(DataBaseName, "LRSRO Connection StringMutation");
                int num = 0;
                foreach (DataRow row in PinTable.Rows)
                {
                    foreach (DataRow row2 in NewVarsTable.Rows)
                    {
                        string TOPANANEM = Convert.ToString(row2[2]);
                       
                        string str3 = "ccode,mut_no,fname,mname,lname,topan_name,buyer_doc_type1,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,buyer_khata_no,usrno";
                        object obj2 = string.Concat(new object[] { "'", Convert.ToString(ccode), "',", Convert.ToInt32(mutno), ",'", Convert.ToString(row2[1]).Trim(), "','", Convert.ToString(row2[2]).Trim(), "','", Convert.ToString(row2[3]).Trim(), "','", Convert.ToString(TOPANANEM).Trim(), "'," });
                        string str4 = string.Concat(new object[] { 
              obj2, Convert.ToInt32(0x35), ",'", Convert.ToString(row["pin"]), "','", Convert.ToString(row["pin1"]), "','", Convert.ToString(row["pin2"]), "','", Convert.ToString(row["pin3"]), "','", Convert.ToString(row["pin4"]), "','", Convert.ToString(row["pin5"]), "','", Convert.ToString(row["pin6"]), 
              "','", Convert.ToString(row["pin7"]), "','", Convert.ToString(row["pin8"]), "','", Convert.ToString(row2[0]), "','",Convert.ToString(row2["usrno"]),"'"
             });
                        string str5 = "mut_kharedi_buyer";
                        DbCommand command2 = handler2.SetCommandText(SchemaName + ".sptblmutregister_all", CommandType.StoredProcedure);
                        handler2.SetInParameter(command2, "@para_schema_name", DbType.String, SchemaName);
                        handler2.SetInParameter(command2, "@para_table_name", DbType.String, str5);
                        handler2.SetInParameter(command2, "@para_column_name", DbType.String, str3);
                        handler2.SetInParameter(command2, "@para_column_value", DbType.String, str4);
                        num = handler2.ExecuteNonQuery(command2);
                    }
                }
                foreach (DataRow row in PinTable.Rows)
                {
                     
                        
                        string str3 = "ccode,mut_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,deal_text";
                     //   object obj2 = string.Concat(new object[] { "'", Convert.ToString(ccode), "',", Convert.ToInt32(mutno), "" });
             //           string str4 = string.Concat(new object[] { 
             // obj2, Convert.ToInt32(0x35), ",'", Convert.ToString(row["pin"]), "','", Convert.ToString(row["pin1"]), "','", Convert.ToString(row["pin2"]), "','", Convert.ToString(row["pin3"]), "','", Convert.ToString(row["pin4"]), "','", Convert.ToString(row["pin5"]), "','", Convert.ToString(row["pin6"]), 
             // "','", Convert.ToString(row["pin7"]), "','", Convert.ToString(row["pin8"]), "','", deal_text, "'"
             //});
                        string str4 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + Convert.ToString(row["pin"]) + "','" + Convert.ToString(row["pin1"]) + "','" + Convert.ToString(row["pin2"]) + "','" + Convert.ToString(row["pin3"]) + "','" + Convert.ToString(row["pin4"]) + "','" + Convert.ToString(row["pin5"]) + "',";
                        str4 += "'" + Convert.ToString(row["pin6"]) + "','" + Convert.ToString(row["pin7"]) + "','" + Convert.ToString(row["pin8"]) + "','" + deal_text + "'";

                        string str5 = "mut_deal";
                        DbCommand command2 = handler2.SetCommandText(SchemaName + ".sptblmutregister_all", CommandType.StoredProcedure);
                        handler2.SetInParameter(command2, "@para_schema_name", DbType.String, SchemaName);
                        handler2.SetInParameter(command2, "@para_table_name", DbType.String, str5);
                        handler2.SetInParameter(command2, "@para_column_name", DbType.String, str3);
                        handler2.SetInParameter(command2, "@para_column_value", DbType.String, str4);
                        num = handler2.ExecuteNonQuery(command2);
                    
                }






                if (num == 0)
                {
                    lblMessage.Text = "Record Not Store";
                }
                else
                {
                    lblMessage.Text = "Record Saved successfully with current Mutation Number as . " + str2;
                }
           
        }

        public void funSetGridList(string DBName, ref GridView gdv, string TableName, string ColValue, string Condition, string Orderby)
        {
            DataBaseHandler handler = new DataBaseHandler(DBName, "LRSRO Connection StringMutation");
            DataSet set = new DataSet();
            string cmdText = "select  " + ColValue + " from " + TableName;
            if (Condition != "")
            {
                cmdText = cmdText + " WHERE " + Condition;
            }
            if (Orderby != "")
            {
                cmdText = cmdText + " Order by " + Orderby;
            }
            DbCommand command = handler.SetCommandText(cmdText, CommandType.Text);
            set = handler.FillDataset(command);
            gdv.DataSource = set.Tables[0].DefaultView;
            gdv.DataBind();
        }

        public DataSet funSetGridListArea(string DBName, ref GridView gdv, string TableName, string ColValue, string Condition, string Orderby)
        {
            DataBaseHandler handler = new DataBaseHandler(DBName, "LRSRO Connection StringMutation");
            DataSet set = new DataSet();
            string cmdText = "select  " + ColValue + " from " + TableName;
            if (Condition != "")
            {
                cmdText = cmdText + " WHERE " + Condition;
            }
            if (Orderby != "")
            {
                cmdText = cmdText + " Order by " + Orderby;
            }
            DbCommand command = handler.SetCommandText(cmdText, CommandType.Text);
            set = handler.FillDataset(command);
            gdv.DataSource = set.Tables[0].DefaultView;
            gdv.DataBind();
            return set;
        }

        public void funSetGridListBuyer(string DBName, ref GridView gdv, string TableName, string ColValue, string Condition, string Orderby, ref DataTable dt)
        {
            DataBaseHandler handler = new DataBaseHandler(DBName, "LRSRO Connection StringMutation");
            DataSet set = new DataSet();
            string cmdText = "select  " + ColValue + " from " + TableName;
            if (Condition != "")
            {
                cmdText = cmdText + " WHERE " + Condition;
            }
            if (Orderby != "")
            {
                cmdText = cmdText + " Order by " + Orderby;
            }
            DbCommand command = handler.SetCommandText(cmdText, CommandType.Text);
            set = handler.FillDataset(command);
            dt = set.Tables[0];
            gdv.DataSource = set.Tables[0].DefaultView;
            gdv.DataBind();
        }

        public void funUpdateSllerBuyerArea(string DataBaseName , string SchemaName,DataTable Sellertable, DataTable Buyertable, string ccode, string mut_no)
        {
            
            
                string[] strArray;
                string str5;
                DataBaseHandler handler;
                DbCommand command;
                int count = Sellertable.Rows.Count;
                for (int i = 0; count > 0; i++)
                {
                    str5 = "";
               //     strArray = Sellertable.Rows[i]["sellerfname"].ToString().Split(new char[] { ' ' });
                    string str = Sellertable.Rows[i]["seller_area_culti"].ToString();
                    string str2 = Sellertable.Rows[i]["seller_remain_area"].ToString();
                    if (str2 == "")
                    {
                        str2 = "0";
                    }

                    string str3 = Sellertable.Rows[i]["seller_area_pot"].ToString();
                    string str4 = Sellertable.Rows[i]["seller_area_pot1"].ToString();
                    string str6 = Sellertable.Rows[i]["na_assessment"].ToString();
                    string str7 = Sellertable.Rows[i]["seller_anne"].ToString();
                    string str8 = Sellertable.Rows[i]["seller_pai"].ToString();
                    string khatano = Sellertable.Rows[i]["Seller_Khata_no"].ToString();
                    str5 =
          "update  " + SchemaName + ".mut_kharedi_seller set seller_area_culti='" + Convert.ToDecimal(str) + "',seller_area_pot='" + Convert.ToDecimal(str3) + "',seller_area_pot2='" + Convert.ToDecimal(str4) + "',seller_anne='" + Convert.ToDecimal(str2) + "',na_assessment='" + Convert.ToDecimal(str6) + "',anne='" + Convert.ToInt32(str7) + "',pai='" + Convert.ToInt32(str8) + "'  where ccode='" + ccode + "'and mut_no='" + mut_no.Trim() + "' and fname='" + Sellertable.Rows[i]["sellerfname"].ToString().Trim() + "'and mname='" + Sellertable.Rows[i]["sellermname"].ToString().Trim() +
          "'and lname='" + Sellertable.Rows[i]["sellerlname"].ToString().Trim() + "' and pin='" + Sellertable.Rows[i]["pin"].ToString() + "' and pin1='" + Sellertable.Rows[i]["pin1"].ToString() + "' and pin2='" + Sellertable.Rows[i]["pin2"].ToString() + "' and pin3='" + Sellertable.Rows[i]["pin3"].ToString() + "' and pin4='" + Sellertable.Rows[i]["pin4"].ToString() + "'and pin5='" + Sellertable.Rows[i]["pin5"].ToString() + "' and pin6='" + Sellertable.Rows[i]["pin6"].ToString() +
          "'and pin7='" + Sellertable.Rows[i]["pin7"].ToString() + "' and pin8='" + Sellertable.Rows[i]["pin8"].ToString() + "' and seller_khata_no='"+khatano+"'";
                    handler = new DataBaseHandler(DataBaseName, "LRSRO Connection StringMutation");
                    command = handler.SetCommandText(str5, CommandType.Text);
                    handler.ExecuteNonQuery(command);
                    count--;
                }
                int num3 = Buyertable.Rows.Count;
                for (int j = 0; num3 > 0; j++)
                {
                    
                    string str6 = Buyertable.Rows[j]["buyer_area_culti"].ToString();
                    //strArray = Buyertable.Rows[j]["buyerfname"].ToString().Split(new char[] { ' ' });
                    string str7 = Buyertable.Rows[j]["na_assessment"].ToString();
                    string str8 = Buyertable.Rows[j]["buyer_area_pot"].ToString();
                    string str9 = Buyertable.Rows[j]["buyer_area_tot"].ToString();
                    string str10 = Buyertable.Rows[j]["buyer_anne"].ToString();
                    string str11 = Buyertable.Rows[j]["buyer_pai"].ToString();
                    string khatano = Buyertable.Rows[j]["buyer_Khata_no"].ToString();
                    str5 =
          "update " + SchemaName + ".mut_kharedi_buyer set buyer_area_culti='" + Convert.ToDecimal(str6) + "',na_assessment='" + Convert.ToDecimal(str7) + "',buyer_area_pot='" + Convert.ToDecimal(str8) + "',buyer_area_tot='" + Convert.ToDecimal(str9) + "',buyer_anne=" + Convert.ToInt32(str10) + ",buyer_pai=" + Convert.ToInt32(str11) + "  where ccode='" + ccode + "'and mut_no='" + mut_no.Trim() + "' and fname='" + Buyertable.Rows[j]["buyerfname"].ToString().Trim() + "'and mname='" + Buyertable.Rows[j]["buyermname"].ToString().Trim() + "'and lname='" + Buyertable.Rows[j]["buyerlname"].ToString().Trim() + "'and pin='" + Buyertable.Rows[j]["pin"].ToString() + "' and pin1='" + Buyertable.Rows[j]["pin1"].ToString() +
          "' and pin2='" + Buyertable.Rows[j]["pin2"].ToString() + "' and pin3='" + Buyertable.Rows[j]["pin3"].ToString() + "' and pin4='" + Buyertable.Rows[j]["pin4"].ToString() + "'and pin5='" + Buyertable.Rows[j]["pin5"].ToString() + "' and pin6='" + Buyertable.Rows[j]["pin6"].ToString() + "'and pin7='" + Buyertable.Rows[j]["pin7"].ToString() + "' and pin8='" + Buyertable.Rows[j]["pin8"].ToString() + "' and buyer_khata_no='" + khatano + "'";
                    handler = new DataBaseHandler(DataBaseName, "LRSRO Connection StringMutation");
                    command = handler.SetCommandText(str5, CommandType.Text);
                    handler.ExecuteNonQuery(command);
                    num3--;
                }

           
        }

        public void GetKhataName(string database, string schmaname,ref DropDownList ddl, string columname, string tablename, string ccode)
        {
            string cmdText = "Select " + columname + " from '"+schmaname+"'.holder_detail where ccode='" + ccode + "'order by fname,mname,lname";
            DataBaseHandler handler = new DataBaseHandler(database, "LRSRO Connection StringMutation");
            DbCommand command = handler.SetCommandText(cmdText, CommandType.Text);
            DataSet set = handler.FillDataset(command);
            ddl.DataSource = set.Tables[0].DefaultView;
            ddl.DataTextField = set.Tables[0].Columns[1].ToString();
            ddl.DataValueField = set.Tables[0].Columns[0].ToString();
            ddl.DataBind();
        }

        public void funUpdateSllerName(string DataBaseName, string SchemaName, DataTable Sellertable, DataTable oldSellertable, DataTable PinTable, string ccode, string mut_no,Label lblmsg)
        {
            int no = 0;
            
           
                string[] strArray;
                string str5;
                DataBaseHandler handler;
                DbCommand command;
                int count = oldSellertable.Rows.Count;
                int coutnpin = PinTable.Rows.Count;
                
                for( int k=0; coutnpin >0; k++)
                {
                for (int i = 0; count > 0; i++)
                {
                    str5 = "";
                    //     strArray = Sellertable.Rows[i]["sellerfname"].ToString().Split(new char[] { ' ' });
                 

                  
                               
                                str5 =
                      "update  " + SchemaName + ".mut_kharedi_seller set fname='" + Sellertable.Rows[i]["firstname"].ToString().Trim() + "', mname='" + Sellertable.Rows[i]["middlename"].ToString().Trim() +
                      "', lname='" + Sellertable.Rows[i]["surname"].ToString().Trim() + "' where  pin='" + PinTable.Rows[k]["pin"].ToString() + "' and pin1='" + PinTable.Rows[k]["pin1"].ToString() + "' and pin2='" + PinTable.Rows[k]["pin2"].ToString() + "' and pin3='" + PinTable.Rows[k]["pin3"].ToString() + "' and pin4='" + PinTable.Rows[k]["pin4"].ToString() + "'and pin5='" + PinTable.Rows[k]["pin5"].ToString() + "' and pin6='" + PinTable.Rows[k]["pin6"].ToString() +
                      "'and pin7='" + PinTable.Rows[k]["pin7"].ToString() + "' and pin8='" + PinTable.Rows[k]["pin8"].ToString() + "' and fname='" + oldSellertable.Rows[i]["firstname"].ToString().Trim() + "'and mname='" + oldSellertable.Rows[i]["middlename"].ToString().Trim() +
                      "'and lname='" + oldSellertable.Rows[i]["surname"].ToString().Trim() + "' and ccode='" + ccode + "' and mut_no='" + mut_no + "'";
                                handler = new DataBaseHandler(DataBaseName, "LRSRO Connection StringMutation");
                                command = handler.SetCommandText(str5, CommandType.Text);
                              no=handler.ExecuteNonQuery(command);
                                count--;
                                
                }
                coutnpin--;
               
                }
                if (no != 0)
                    lblmsg.Text = "Record succefully updated......!!!!";
                else
                    lblmsg.Text = "Record is not updated...!!";
 
           
        }

        public void funUpdateSllerBuyerAreanew(string DataBaseName, string SchemaName, DataTable Sellertable, DataTable Buyertable,DataTable oldseller,DataTable oldbuyer, string ccode, string mut_no)
        {
            
            
                string[] strArray;
                string str5;
                DataBaseHandler handler;
                DbCommand command;
                int count = Sellertable.Rows.Count;
                for (int i = 0; count > 0; i++)
                {
                    str5 = "";
                    //     strArray = Sellertable.Rows[i]["sellerfname"].ToString().Split(new char[] { ' ' });
                    string str = Sellertable.Rows[i]["seller_area_h"].ToString();
                    string str2 = Sellertable.Rows[i]["seller_remain_area"].ToString();
                    if (str2 == "")
                    {
                        str2 = "0";
                    }

                    string str3 = Sellertable.Rows[i]["seller_area_pot"].ToString();
                    string str4 = Sellertable.Rows[i]["seller_area_pot1"].ToString();
                    string str6 = Sellertable.Rows[i]["na_assessment"].ToString();
                    string str7 = Sellertable.Rows[i]["seller_anne"].ToString();
                    string str8 = Sellertable.Rows[i]["seller_pai"].ToString();
                    string khatano = Sellertable.Rows[i]["Seller_Khata_no"].ToString();
          //          str5 =
          //"update  " + SchemaName + ".mut_kharedi_seller set seller_area_culti='" + Convert.ToDecimal(str) + "',seller_area_pot='" + Convert.ToDecimal(str3) + "',seller_area_pot2='" + Convert.ToDecimal(str4) + "',seller_anne='" + Convert.ToDecimal(str2) + "',na_assessment='" + Convert.ToDecimal(str6) + "',anne='" + Convert.ToInt32(str7) + "',pai='" + Convert.ToInt32(str8) + "'  where ccode='" + ccode + "'and mut_no='" + mut_no.Trim() + "' and fname='" + Sellertable.Rows[i]["sellerfname"].ToString().Trim() + "'and mname='" + Sellertable.Rows[i]["sellermname"].ToString().Trim() +
          //"'and lname='" + Sellertable.Rows[i]["sellerlname"].ToString().Trim() + "' and pin='" + Sellertable.Rows[i]["pin"].ToString() + "' and pin1='" + Sellertable.Rows[i]["pin1"].ToString() + "' and pin2='" + Sellertable.Rows[i]["pin2"].ToString() + "' and pin3='" + Sellertable.Rows[i]["pin3"].ToString() + "' and pin4='" + Sellertable.Rows[i]["pin4"].ToString() + "'and pin5='" + Sellertable.Rows[i]["pin5"].ToString() + "' and pin6='" + Sellertable.Rows[i]["pin6"].ToString() +
          //"'and pin7='" + Sellertable.Rows[i]["pin7"].ToString() + "' and pin8='" + Sellertable.Rows[i]["pin8"].ToString() + "' and seller_khata_no='" + khatano + "'";




                    str5 =
         "update  " + SchemaName + ".mut_kharedi_seller set fname='" + Sellertable.Rows[i]["sellerfname"].ToString().Trim() + "',mname='" + Sellertable.Rows[i]["sellermname"].ToString().Trim() + "', lname='" + Sellertable.Rows[i]["sellerlname"].ToString().Trim() + "', seller_khata_no='" + khatano + "', seller_area_culti='" + Convert.ToDecimal(str) + "',seller_area_pot='" + Convert.ToDecimal(str3) + "',seller_area_pot2='" + Convert.ToDecimal(str4) + "',seller_anne='" + Convert.ToDecimal(str2) + "',na_assessment='" + Convert.ToDecimal(str6) + "',anne='" + Convert.ToInt32(str7) + "',pai='" + Convert.ToInt32(str8) + "'  where ccode='" + ccode + "'and mut_no='" + mut_no.Trim() + "'and  fname='" + oldseller.Rows[i]["sellerfname"].ToString().Trim() + "' and mname='" + oldseller.Rows[i]["sellermname"].ToString().Trim() +
         "'and lname='" + oldseller.Rows[i]["sellerlname"].ToString().Trim() + "' and pin='" + Sellertable.Rows[i]["pin"].ToString() + "' and pin1='" + Sellertable.Rows[i]["pin1"].ToString() + "' and pin2='" + Sellertable.Rows[i]["pin2"].ToString() + "' and pin3='" + Sellertable.Rows[i]["pin3"].ToString() + "' and pin4='" + Sellertable.Rows[i]["pin4"].ToString() + "'and pin5='" + Sellertable.Rows[i]["pin5"].ToString() + "' and pin6='" + Sellertable.Rows[i]["pin6"].ToString() +
         "'and pin7='" + Sellertable.Rows[i]["pin7"].ToString() + "' and pin8='" + Sellertable.Rows[i]["pin8"].ToString() + "' and seller_khata_no='" + oldseller.Rows[i]["seller_khata_no"].ToString() + "'";
                    handler = new DataBaseHandler(DataBaseName, "LRSRO Connection StringMutation");
                    command = handler.SetCommandText(str5, CommandType.Text);
                    handler.ExecuteNonQuery(command);
                    count--;
                }
                int num3 = Buyertable.Rows.Count;
                for (int j = 0; num3 > 0; j++)
                {

                    string str6 = Buyertable.Rows[j]["buyer_area_culti"].ToString();
                    //strArray = Buyertable.Rows[j]["buyerfname"].ToString().Split(new char[] { ' ' });
                    string str7 = Buyertable.Rows[j]["na_assessment"].ToString();
                    string str8 = Buyertable.Rows[j]["buyer_area_pot"].ToString();
                    string str9 = Buyertable.Rows[j]["buyer_area_tot"].ToString();
                    string str10 = Buyertable.Rows[j]["buyer_anne"].ToString();
                    string str11 = Buyertable.Rows[j]["buyer_pai"].ToString();
                    string khatano = Buyertable.Rows[j]["buyer_Khata_no"].ToString();
          //          str5 =
          //"update " + SchemaName + ".mut_kharedi_buyer set buyer_area_culti='" + Convert.ToDecimal(str6) + "',na_assessment='" + Convert.ToDecimal(str7) + "',buyer_area_pot='" + Convert.ToDecimal(str8) + "',buyer_area_tot='" + Convert.ToDecimal(str9) + "',buyer_anne=" + Convert.ToInt32(str10) + ",buyer_pai=" + Convert.ToInt32(str11) + "  where ccode='" + ccode + "'and mut_no='" + mut_no.Trim() + "' and fname='" + Buyertable.Rows[j]["buyerfname"].ToString().Trim() + "'and mname='" + Buyertable.Rows[j]["buyermname"].ToString().Trim() + "'and lname='" + Buyertable.Rows[j]["buyerlname"].ToString().Trim() + "'and pin='" + Buyertable.Rows[j]["pin"].ToString() + "' and pin1='" + Buyertable.Rows[j]["pin1"].ToString() +
          //"' and pin2='" + Buyertable.Rows[j]["pin2"].ToString() + "' and pin3='" + Buyertable.Rows[j]["pin3"].ToString() + "' and pin4='" + Buyertable.Rows[j]["pin4"].ToString() + "'and pin5='" + Buyertable.Rows[j]["pin5"].ToString() + "' and pin6='" + Buyertable.Rows[j]["pin6"].ToString() + "'and pin7='" + Buyertable.Rows[j]["pin7"].ToString() + "' and pin8='" + Buyertable.Rows[j]["pin8"].ToString() + "' and buyer_khata_no='" + khatano + "'";

                    str5 =
        "update " + SchemaName + ".mut_kharedi_buyer set buyer_area_culti='" + Convert.ToDecimal(str6) + "',na_assessment='" + Convert.ToDecimal(str7) + "',buyer_area_pot='" + Convert.ToDecimal(str8) + "',buyer_area_tot='" + Convert.ToDecimal(str9) + "',buyer_anne=" + Convert.ToInt32(str10) + ",buyer_pai=" + Convert.ToInt32(str11) + ",fname='" + Buyertable.Rows[j]["buyerfname"].ToString().Trim() + "', mname='" + Buyertable.Rows[j]["buyermname"].ToString().Trim() + "',lname='" + Buyertable.Rows[j]["buyerlname"].ToString().Trim() + "',buyer_khata_no='" + khatano + "'  where ccode='" + ccode + "'and mut_no='" + mut_no.Trim() + "', and fname='" + oldbuyer.Rows[j]["buyerfname"].ToString().Trim() + "'and mname='" + oldbuyer.Rows[j]["buyermname"].ToString().Trim() + "'and lname='" + oldbuyer.Rows[j]["buyerlname"].ToString().Trim() + "'and pin='" + Buyertable.Rows[j]["pin"].ToString() + "' and pin1='" + Buyertable.Rows[j]["pin1"].ToString() +
        "' and pin2='" + Buyertable.Rows[j]["pin2"].ToString() + "' and pin3='" + Buyertable.Rows[j]["pin3"].ToString() + "' and pin4='" + Buyertable.Rows[j]["pin4"].ToString() + "'and pin5='" + Buyertable.Rows[j]["pin5"].ToString() + "' and pin6='" + Buyertable.Rows[j]["pin6"].ToString() + "'and pin7='" + Buyertable.Rows[j]["pin7"].ToString() + "' and pin8='" + Buyertable.Rows[j]["pin8"].ToString() + "' and buyer_khata_no='" + oldbuyer.Rows[j]["buyer_Khata_no"].ToString().Trim() + "'";
                    handler = new DataBaseHandler(DataBaseName, "LRSRO Connection StringMutation");
                    command = handler.SetCommandText(str5, CommandType.Text);
                    handler.ExecuteNonQuery(command);
                    num3--;
                }

           
        }

        public int sellerdateupdatetion(string DataBaseName, string SchemaName, string ccode, int mutno, DataTable NewVarsTable)
        {
            int num = 0;
            
            
                DataBaseHandler handler2 = new DataBaseHandler(DataBaseName, "LRSRO Connection StringMutation");
                // DateTime date1 = new DateTime();
                string date1;
                string str3, str4;
                string userid = objclscommonfunc.funReturnSingleValue(DataBaseName, SchemaName + ".m_officermast", "username", "ccode='" + ccode + "' and user_type='1'", "");

                foreach (DataRow row2 in NewVarsTable.Rows)
                {
                    //                        string name  = Convert.ToString(row2[1]).Trim()+"  "+ Convert.ToString(row2[2]).Trim()+"  "+ Convert.ToString(row2[3]).Trim();
                    string name = Convert.ToString(row2["name"]).Trim();
                    string datew = row2["sellerdate"].ToString();
                    if (datew.Trim() != "" && datew != null)
                    {
                        //date1 =Convert.ToDateTime( func.ConvertDateToMMddyyyyFormat(Convert.ToString(row2["sellerdate"])));
                        // date1 = Convert.ToDateTime(func.ConvertDateToMMddyyyyFormat(Convert.ToString(row2["sellerdate"])));
                        DateTime dtTran = DateTime.ParseExact(datew, "dd/MM/yyyy", null);
                        date1 = func.ConvertDateToMMddyyyyFormat(dtTran.ToShortDateString());


                        //date1 = func.ConvertDateToMMddyyyyFormat(Convert.ToString(row2["sellerdate"]));
                        str3 = "ccode,mut_no,name,notice_date";
                        str4 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + name + "','" + date1 + "'";
                    }
                    else
                    {
                        str3 = "ccode,mut_no,name";
                        str4 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + name + "'";
                    }
                    string str5 = "notice_names";
                    DbCommand command2 = handler2.SetCommandText(SchemaName + ".sptblmutregister_all_em", CommandType.StoredProcedure);
                    handler2.SetInParameter(command2, "@para_schema_name", DbType.String, SchemaName);
                    handler2.SetInParameter(command2, "@para_table_name", DbType.String, str5);
                    handler2.SetInParameter(command2, "@para_column_name", DbType.String, str3);
                    handler2.SetInParameter(command2, "@para_column_value", DbType.String, str4);
                    handler2.SetInParameter(command2, "@para_login_id", DbType.String, userid);
                    handler2.SetInParameter(command2, "@para_app_name", DbType.String, "reEdit");
                    num = handler2.ExecuteNonQuery(command2);
                }
                return num;
           
            
        }

        public void updatedateseller(string DataBaseName, string SchemaName, string ccode, int mutno, DataTable NewVarsTable)
        {
           
                DataBaseHandler handler2 = new DataBaseHandler(DataBaseName, "LRSRO Connection StringMutation");
                DbCommand command;
                string date1;

                string loginid = objclscommonfunc.funReturnSingleValue(DataBaseName, SchemaName + ".m_officermast", "username", "ccode='" + ccode + "' and user_type='1'", "");

                //DateTime date1 = new DateTime();
                foreach (DataRow row3 in NewVarsTable.Rows)
                {
                    string name = Convert.ToString(row3[1]).Trim() + "  " + Convert.ToString(row3[2]).Trim() + "  " + Convert.ToString(row3[3]).Trim();
                    string datew = row3["sellerdate"].ToString().Trim();

                    if (datew != "")
                    {
                        DateTime dtTran = DateTime.ParseExact(datew, "dd/MM/yyyy", null);
                        date1 = func.ConvertDateToMMddyyyyFormat(dtTran.ToShortDateString());

                        command = handler2.SetCommandText(SchemaName + ".sp_update_em", CommandType.StoredProcedure);
                        handler2.SetInParameter(command, "@para_table_name", DbType.String, SchemaName + ".notice_names");
                        handler2.SetInParameter(command, "@para_set_column", DbType.String, "notice_date='" + date1 + "'");
                        handler2.SetInParameter(command, "@para_condition_column", DbType.String, "name='" + row3["name"] + "' and  ccode='" + Convert.ToString(ccode) + "'and mut_no=" + Convert.ToInt32(mutno) + "");
                        handler2.SetInParameter(command, "@para_login_id", DbType.String, loginid);
                        handler2.SetInParameter(command, "@para_app_name", DbType.String, "reEdit");
                        handler2.ExecuteNonQuery(command);

                        //string str5 = "update " + SchemaName + ".notice_names set notice_date='" + date1 + "' where name='" + row3["name"] + "' and  ccode='" + Convert.ToString(ccode) + "'and mut_no=" + Convert.ToInt32(mutno) + "";
                        //command = handler2.SetCommandText(str5, CommandType.Text);
                    }
                    else
                    {
                        command = handler2.SetCommandText(SchemaName + ".sp_update_em", CommandType.StoredProcedure);
                        handler2.SetInParameter(command, "@para_table_name", DbType.String, SchemaName + ".notice_names");
                        handler2.SetInParameter(command, "@para_set_column", DbType.String, "notice_date=NULL");
                        handler2.SetInParameter(command, "@para_condition_column", DbType.String, "name='" + row3["name"] + "' and  ccode='" + Convert.ToString(ccode) + "'and mut_no=" + Convert.ToInt32(mutno) + "");
                        handler2.SetInParameter(command, "@para_login_id", DbType.String, loginid);
                        handler2.SetInParameter(command, "@para_app_name", DbType.String, "reEdit");
                        handler2.ExecuteNonQuery(command);

                        //string str54 = "update " + SchemaName + ".notice_names set notice_date=NULL where name='" + row3["name"] + "' and  ccode='" + Convert.ToString(ccode) + "'and mut_no=" + Convert.ToInt32(mutno) + "";
                        //command = handler2.SetCommandText(str54, CommandType.Text);
                        //handler2.ExecuteNonQuery(command);
                    }
                }
            
        }       
       

       
        
       
        public string ConvertDateToddMMyyyyFormat(string strDate)
        {
            string[] strarrDate;
            char[] charseperator = new char[2];
            charseperator[0] = '/';
            charseperator[1] = '-';
            //    charseperator[0] =
            string strFinalDate;
            try
            {
                strarrDate = strDate.Split(charseperator);
                strFinalDate = strarrDate[1] + "/" + strarrDate[0] + "/" + strarrDate[2];
                return (Convert.ToString(strFinalDate));
            }
            catch
            {
                return (Convert.ToString(strDate));
            }
        }
    }



}
