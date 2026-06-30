// JScript File

    function Ismpty(gettestbox,e)
	{ 
	 if ((e.keyCode>=65 && e.keyCode<=90 )||(e.keyCode>=97 && e.keyCode<=122 ) ||  e.keyCode==32 || e.keyCode==46)
	       {}
	 else     
	       { 
	       e.preventDefault();
	         window.alert('Please, Enter User id or password');
	          e.keyCode=0;
	       }
	 }
    function IsCancel(gettestbox,e)
	{
  	        e.keyCode=0;
	}	
	
	
	
	function IsDigit(gettestbox,e)
	{
	if(e.keyCode!=13)
	{
  	    if (e.keyCode<46 || e.keyCode>57)
	        { 
	          if(e.keyCode<2406 || e.keyCode>2415)
	          {
	             e.preventDefault();
	             window.alert('कृपया योग्य अंक भरा.');
	            
	             
	          }
	         else
	          {	 
	             
	       
	          if(e.keyCode==2406)
	          {
	           gettestbox.value = gettestbox.value.concat('0');
	          }
	          if (e.keyCode==2407)
	          {
	          gettestbox.value = gettestbox.value.concat('1');
	          }
	          if (e.keyCode==2408)
	          {
	          gettestbox.value = gettestbox.value.concat('2');
	          }
	          if (e.keyCode==2409)
	          {
	          gettestbox.value = gettestbox.value.concat('3');
	          }
	          if (e.keyCode==2410)
	          {
	          gettestbox.value = gettestbox.value.concat('4');
	          }
	          if (e.keyCode==2411)
	          {
	          gettestbox.value = gettestbox.value.concat('5');
	          }
	          if (e.keyCode==2412)
	          {
	          gettestbox.value = gettestbox.value.concat('6');
	          }
	          if (e.keyCode==2413)
	          {
	          gettestbox.value = gettestbox.value.concat('7');
	          }
	          if (e.keyCode==2414)
	          {
	          gettestbox.value = gettestbox.value.concat('8');
	          }
	          if (e.keyCode==2415)
	          {
	          gettestbox.value = gettestbox.value.concat('9');
	          }
	           e.preventDefault();      
	          
	          }
	     }	       
	     } 
	    
	}
	
	
	function IsNOTDigit(gettestbox,e)
	{
	if(e.keyCode!=13)
	{
  	       if (e.keyCode<46 || e.keyCode>57)
	        { 
	          if(e.keyCode<2406 || e.keyCode>2415)
	          {
	            
	             
	          }
	          else
	          {
	          e.preventDefault();
	          window.alert('कृपया योग्य माहिती भरा.');
	              e.keyCode=0;
	          }
	     } 
	      else
	          {
	          e.preventDefault();
	          window.alert('कृपया योग्य माहिती भरा.');
	              e.keyCode=0;
	          }  
	          }  
	}

	function IsNOTName(gettestbox, e) {
	    if (e.keyCode != 13) {
	        if (e.keyCode < 46 || e.keyCode > 57) {
	            if (e.keyCode < 2406 || e.keyCode > 2415) {


	            }
	            else {
	                e.preventDefault();
	                window.alert('कृपया योग्य नाव भरा.');
	                e.keyCode = 0;
	            }
	        }
	        else {
	            e.preventDefault();
	            window.alert('कृपया योग्य नाव भरा.');
	            e.keyCode = 0;
	        }
	    }
	}
	
	
	
  function IsDigitAndDecimal(gettestbox,e)
	{
	if(e.keyCode!=13)
	{
  	    if (e.keyCode<46 || e.keyCode>57 || e.keyCode==47)
	        { 
	          if(e.keyCode<2406 || e.keyCode>2415)
	          {
	          e.preventDefault();
	            window.alert('कृपया योग्य अंक भरा.');
	            e.keyCode=0;
	          }
	        }
	    else
	        {  
	          var i,str,a;
	          str= gettestbox.value;
	          a=parseFloat(str);
	          
	          if (gettestbox.value.length>21)
	          {
	          e.preventDefault();
	            window.alert('Number Is Too Large');
	            e.keyCode=0;
	          }
	                  
	          for (i = 0; i<=gettestbox.value.length; i++) 
                      {
                          if (str.charAt(i)=="." && e.keyCode==46 )
                             {
                                e.keyCode=0;
                             }
                           if (str.indexOf(".")!=-1 && (gettestbox.value.length - str.indexOf(".") > 4 ))
                             {
                                e.keyCode=0;
                             }
                      }
                }  
                }    
	}
	
	
	
	 function IsAlphabet(gettestbox,e)
	{ 
	 if ((e.keyCode>=65 && e.keyCode<=90 )||(e.keyCode>=97 && e.keyCode<=122 ) ||  e.keyCode==32 || e.keyCode==46)
	       {}
//	 else     
//	       { 
//	          window.alert('Please, Enter Only Alphabet');
//	          e.keyCode=0;
//	       }
	 }
	 
  function CheckForPasteForAlphabet(gettestbox)
	  {
	      var i,str,strChar ;
	      var strValidChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ -";
	      str= gettestbox.value;
	          	        
	      for (i = 0; i<=gettestbox.value.length; i++) 
                 {
                   strChar =str.charAt(i)
                   if (strValidChars.indexOf(strChar ) == -1)
                     {
                     e.preventDefault();
                        window.alert('Please, Enter Only Alphabet');
                        gettestbox.value=""
                        gettestbox.focus()
                     }
                 }
	  }	
	  function setTextBoxFocus(gettestbox,e)
	  {
	      var i,str,strChar ;
	      var strValidChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ-";
	      str= gettestbox.value;
	          	        
	      for (i = 0; i<=gettestbox.value.length; i++) 
                 {
                   strChar =str.charAt(i)
                   if (strValidChars.indexOf(strChar ) == -1)
                     {
                     e.preventDefault();
                        window.alert('Please, Enter Only Alphabet');
                        gettestbox.value=""
                        gettestbox.focus()
                     }
                 }
	  }
	  
	  
	  function validate_dates(gettestbox)
	{
		var from,to,dd,mm,yy,i;
		   alert(gettestbox.value);
			dates=gettestbox.value.split("/");
			dd=dates[0];
			mm=dates[1];
			yy=dates[2];
		  
		 	  
			for (i=0;i<gettestbox.value.length;i++)
			{
				onechar=gettestbox.value.substring(i,i+1);
				if ( ((parseInt(onechar)>=0) && (parseInt(onechar)<=9)) || (onechar=="/") )
				{
					if ( ((parseInt(mm)==2)||(parseInt(mm)==02)) && (parseInt(dd)>29) )
					{
						alert("Enter Proper Date For Month February i.e Date Should be Less Than 30");
						gettestbox.focus();
						return false;
						break;
					}
					else
					{
						if ( ( ((parseInt(mm)==1)||(parseInt(mm)==01)) || ((parseInt(mm)==3)||(parseInt(mm)==03)) || ((parseInt(mm)==5)||(parseInt(mm)==05)) || ((parseInt(mm)==7)||(parseInt(mm)==07)) || ((parseInt(mm)==8)||(parseInt(mm)==08)) || (parseInt(mm)==10) || (parseInt(mm)==12) ) && (parseInt(dd)>31) && (parseInt(mm)<=12) && (parseInt(mm)>0)  && (parseInt(dd)>0) )
						{
							alert("Enter Proper Month and Date Should be Less Than 32");
							gettestbox.focus();
							return false;
							break;
						}
						else
						{
							if ( ( ((parseInt(mm)==4)||(parseInt(mm)==04)) || ((parseInt(mm)==6)||(parseInt(mm)==06)) || ((parseInt(mm)==9)||(parseInt(mm)==09)) || (parseInt(mm)==11) ) && (parseInt(dd)>30) && (parseInt(mm)<=11) && (parseInt(mm)>0)  && (parseInt(dd)>0) )
							{
								alert("Enter Proper Month and Date Should be Less Than 31");
								gettestbox.focus();
								return false;
								break;
							}
							else
							{   
								if ( (parseInt(mm)>12) || (parseInt(mm)==0) || (parseInt(dd)==0) || (parseInt(mm)==00) || (parseInt(dd)==00) )
								{
									alert("Enter Proper Month and Date Format");
									gettestbox.focus();
									return false;
									break;
								}
							}
						}
					}
				
				}
				else
				{
					alert("Enter Proper Date Format i.e dd/mm/yy ");
					gettestbox.focus();
					return false;
					break;
				}
			} //end of second for
			
	}//end of Function  
       function chktextbox(source, args)
  		{
   			if(document.getElementsById('lvwAttributeTypes').value == "")
  			{
  	            			   alert("you not select value"); 
  	            			   return false;
  	            			//args.IsValid = false;
   			}
  			else
  			{
  				 alert("you select value"); 
  	            			   return false;
  			}
  		}

