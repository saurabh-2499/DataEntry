using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Common;
using Npgsql;
using System.Text.RegularExpressions;

namespace NIC.WebLMISLibrary
{
    public class CheckDataPendingMutation
    {

        public string CheckSurveyDataRespectiveKhata(string databaseName, string schemaName, string ccode, string p_pin, string p_pin1, string p_pin2, string p_pin3, string p_pin4, string p_pin5, string p_pin6, string p_pin7, string p_pin8, string khata_no, string mut_type)
        {
            DataBaseHandler handler = new DataBaseHandler(databaseName, "LRSRO Connection StringMutation");
            DataSet set = new DataSet();
            string cmdText = "select   avg(mksk.nave_area)-sum(mkbk.purchase_area)||'#'||avg(mksk.nave_pot)-sum(mkbk.purchase_pot) as available_area  from  " + schemaName + ".mutregister as m " +
                             "join  "+schemaName+".mut_kharedi " +
                             "as mk on m.ccode=mk.ccode and m.mut_no=mk.mut_no " +
                             "join "+schemaName+".mut_kharedi_buyer_khata as mkbk " +
                             "on mk.ccode=mkbk.ccode and mk.mut_no=mkbk.mut_no and mk.pin=mkbk.pin and mk.pin1=mkbk.pin1 and mk.pin2=mkbk.pin2 and mk.pin3=mkbk.pin3 and mk.pin4=mkbk.pin4  and mk.pin5=mkbk.pin5 and mk.pin6=mkbk.pin6 and mk.pin7=mkbk.pin7 " +
                             "and mk.pin8=mkbk.pin8 " +
                             "join "+schemaName+".mut_kharedi_seller_khata as mksk " +
                             "on mk.ccode=mksk.ccode and mk.mut_no=mksk.mut_no and mk.pin=mksk.pin and mk.pin1=mksk.pin1 and mk.pin2=mksk.pin2 and mk.pin3=mksk.pin3 and mk.pin4=mksk.pin4  and mk.pin5=mksk.pin5 and mk.pin6=mksk.pin6 and mk.pin7=mksk.pin7 " +
                             "and mk.pin8=mksk.pin8 " +
                             " join  " + schemaName + ".m_village_census as v on m.ccode=v.ccode and m.mut_no>=v.pending_mut_no_cnt where mk.ccode='" + ccode + "' and mk.pin='" + p_pin + "' and mk.pin1='" + p_pin1 + "'  and " +
                             "mk.pin2='" + p_pin2 + "' and mk.pin3='" + p_pin3 + "' and mk.pin4='" + p_pin4 + "' and mk.pin5='" + p_pin5 + "' and mk.pin6='" + p_pin6 + "' and mk.pin7='" + p_pin7 + "' and mk.pin8='" + p_pin8 + "' and mksk.khata_no='" + khata_no + "'  and seller_khata_no='" + khata_no + "' " +
                             "and mk.or_code4<>5 ";
            DbCommand command = handler.SetCommandText(cmdText, CommandType.Text);
            DataSet ds = handler.FillDataset(command);
            if (ds != null && Convert.ToString(ds.Tables[0].Rows[0][0])!="")
            {
                return Convert.ToString(ds.Tables[0].Rows[0]["available_area"]);
            }

            return "";
        }

        public DataSet CheckSurveyMutationAndAreaRespectiveKhata(string databaseName, string schemaName, string ccode, string p_pin, string p_pin1, string p_pin2, string p_pin3, string p_pin4, string p_pin5, string p_pin6, string p_pin7, string p_pin8, string khata_no, string mut_type)
        {
            DataBaseHandler handler = new DataBaseHandler(databaseName, "LRSRO Connection StringMutation");
            DataSet set = new DataSet();
            string cmdText = "select   sum(mkbk.purchase_area) as purchase_area,sum(mkbk.purchase_pot) as purchase_pot,m.mut_no   from  " + schemaName + ".mutregister as m " +
                             "join  " + schemaName + ".mut_kharedi " +
                             "as mk on m.ccode=mk.ccode and m.mut_no=mk.mut_no " +
                             "join " + schemaName + ".mut_kharedi_buyer_khata as mkbk " +
                             "on mk.ccode=mkbk.ccode and mk.mut_no=mkbk.mut_no and mk.pin=mkbk.pin and mk.pin1=mkbk.pin1 and mk.pin2=mkbk.pin2 and mk.pin3=mkbk.pin3 and mk.pin4=mkbk.pin4  and mk.pin5=mkbk.pin5 and mk.pin6=mkbk.pin6 and mk.pin7=mkbk.pin7 " +
                             "and mk.pin8=mkbk.pin8 " +
                             "join " + schemaName + ".mut_kharedi_seller_khata as mksk " +
                             "on mk.ccode=mksk.ccode and mk.mut_no=mksk.mut_no and mk.pin=mksk.pin and mk.pin1=mksk.pin1 and mk.pin2=mksk.pin2 and mk.pin3=mksk.pin3 and mk.pin4=mksk.pin4  and mk.pin5=mksk.pin5 and mk.pin6=mksk.pin6 and mk.pin7=mksk.pin7 " +
                             "and mk.pin8=mksk.pin8 " +
                             " join  " + schemaName + ".m_village_census as v on m.ccode=v.ccode and m.mut_no>=v.pending_mut_no_cnt where mk.ccode='" + ccode + "' and mk.pin='" + p_pin + "' and mk.pin1='" + p_pin1 + "'  and " +
                             "mk.pin2='" + p_pin2 + "' and mk.pin3='" + p_pin3 + "' and mk.pin4='" + p_pin4 + "' and mk.pin5='" + p_pin5 + "' and mk.pin6='" + p_pin6 + "' and mk.pin7='" + p_pin7 + "' and mk.pin8='" + p_pin8 + "' and mksk.khata_no='" + khata_no + "'  and seller_khata_no='" + khata_no + "' " +
                             "and m.mut_status_code=1 and mk.or_code4<>2 and mk.or_code4<>5  group by m.mut_no";
            DbCommand command = handler.SetCommandText(cmdText, CommandType.Text);
            DataSet ds = handler.FillDataset(command);
           

            return ds;
        }       


        public DataSet CheckSurveyMutationRespectiveKhata(string databaseName, string schemaName, string ccode, string p_pin, string p_pin1, string p_pin2, string p_pin3, string p_pin4, string p_pin5, string p_pin6, string p_pin7, string p_pin8, string khata_no, string document_date)
        {
            DataBaseHandler handler = new DataBaseHandler(databaseName, "LRSRO Connection StringMutation");
            DataSet set = new DataSet();
            string cmdText = "select   distinct m.mut_no   from  " + schemaName + ".mutregister as m "+
                             "join  " + schemaName + ".mut_kharedi "+ 
                             "as mk on m.ccode=mk.ccode and m.mut_no=mk.mut_no "+                              
                             "join " + schemaName + ".mut_kharedi_seller_khata as mksk "+
                             "on mk.ccode=mksk.ccode and mk.mut_no=mksk.mut_no and mk.pin=mksk.pin and mk.pin1=mksk.pin1 and mk.pin2=mksk.pin2 and mk.pin3=mksk.pin3 and mk.pin4=mksk.pin4  and mk.pin5=mksk.pin5 and mk.pin6=mksk.pin6 and mk.pin7=mksk.pin7 "+
                             "and mk.pin8=mksk.pin8 "+
                             "join  " + schemaName + ".mutregister_audit as ma on m.ccode=ma.ccode and "+
                             "m.mut_no=ma.mut_no join  " + schemaName + ".m_village_census as v on m.ccode=v.ccode and m.mut_no>=v.pending_mut_no_cnt where mk.ccode='" + ccode + "' and mk.pin='" + p_pin + "' and mk.pin1='" + p_pin1 + "'  and " +
                             "mk.pin2='" + p_pin2 + "' and mk.pin3='" + p_pin3 + "' and mk.pin4='" + p_pin4 + "' and mk.pin5='" + p_pin5 + "' and mk.pin6='" + p_pin6 + "' and mk.pin7='" + p_pin7 + "' and mk.pin8='" + p_pin8 + "' and mksk.khata_no='" + khata_no + "' " +
                             "and m.ref_date2< '" + document_date + "' and m.mut_status_code=1 and mk.or_code4<>2 and mk.or_code4<>5  and ma.app_name='reEdit' ";
            DbCommand command = handler.SetCommandText(cmdText, CommandType.Text);
            DataSet ds = handler.FillDataset(command);


            return ds;
        }

    }
}
