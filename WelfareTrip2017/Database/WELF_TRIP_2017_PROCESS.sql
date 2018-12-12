CREATE OR REPLACE PROCEDURE WELF_TRIP_2017_PROCESS
IS


V_CUR_COMPANY VARCHAR2(50); 
V_CUR_EPF VARCHAR2(50); 

V_SEQ_ID WELF_TRIP_2017_MAIN.SEQ_ID%TYPE;

V_TEMP_COUNT NUMBER;
V_TEMP_COUNTER NUMBER;

BEGIN

DELETE FROM WELF_TRIP_2017_MAIN;



FOR  I IN(SELECT t.company,t.branch_dept,t.epf_no,t.insured_name FROM WELF_TRIP_2017_TEMP T WHERE t.relation='EP' )
LOOP

 V_SEQ_ID:=0;

 SELECT CASE WHEN MAX(SEQ_ID)  IS NULL THEN 1 ELSE TO_NUMBER((MAX(SEQ_ID)+1)) END INTO V_SEQ_ID FROM WELF_TRIP_2017_MAIN;
	 
	 
	V_CUR_COMPANY:=I.COMPANY;
	
	V_CUR_EPF:=I.EPF_NO;
	

	INSERT INTO WELF_TRIP_2017_MAIN(
			 SEQ_ID ,
			  COMPANY	,
			  BRANCH_DEPT	,
			  EPF_NO     ,
			  MEMBER_NAME    ,
			  SPOUSE_NAME
		)
	VALUES(
			V_SEQ_ID,
			I.company,
			I.branch_dept,
			I.epf_no,
			I.insured_name,
			(SELECT t.insured_name FROM WELF_TRIP_2017_TEMP T WHERE t.company=I.company and t.epf_no=I.epf_no and t.relation='SP')
	);
	
	
	
	
	
--------------
		V_TEMP_COUNT:=0;
		V_TEMP_COUNTER:=1;
			
			FOR  J IN(SELECT t.insured_name,t.DOB FROM WELF_TRIP_2017_TEMP T WHERE  t.company=I.company and t.epf_no=I.epf_no AND t.relation in ('SN','DG') order by t.DOB )
			LOOP
			
			SELECT count(*) INTO V_TEMP_COUNT FROM WELF_TRIP_2017_TEMP T WHERE  t.company=I.company and t.epf_no=I.epf_no AND t.relation in ('SN','DG') ;

			IF V_TEMP_COUNTER<=V_TEMP_COUNT  THEN 			
				IF V_TEMP_COUNTER =1 THEN 
					UPDATE WELF_TRIP_2017_MAIN M SET
						 CH1_NAME =J.insured_name  ,
						 CH1_DOB= to_date(J.DOB,'DD/MM/RRRR')  
					WHERE M.SEQ_ID=V_SEQ_ID;
				V_TEMP_COUNTER:=V_TEMP_COUNTER+1;
				CONTINUE;
				END IF;	
			END IF;	
			
			IF V_TEMP_COUNTER<=V_TEMP_COUNT  THEN 		
				IF V_TEMP_COUNTER =2 THEN 
					UPDATE WELF_TRIP_2017_MAIN M SET
						 CH2_NAME =J.insured_name  ,
						 CH2_DOB= to_date(J.DOB,'DD/MM/RRRR')  
					WHERE M.SEQ_ID=V_SEQ_ID;
				V_TEMP_COUNTER:=V_TEMP_COUNTER+1;
				CONTINUE;
				END IF;		
			END IF;	

			IF V_TEMP_COUNTER<=V_TEMP_COUNT  THEN 		
				IF V_TEMP_COUNTER =3 THEN 
					UPDATE WELF_TRIP_2017_MAIN M SET
						 CH3_NAME =J.insured_name  ,
						 CH3_DOB= to_date(J.DOB,'DD/MM/RRRR')  
					WHERE M.SEQ_ID=V_SEQ_ID;
				V_TEMP_COUNTER:=V_TEMP_COUNTER+1;
				CONTINUE;
				END IF;	
			END IF;	

			IF V_TEMP_COUNTER<=V_TEMP_COUNT  THEN 		
				IF V_TEMP_COUNTER =4 THEN 
					UPDATE WELF_TRIP_2017_MAIN M SET
						 CH4_NAME =J.insured_name  ,
						 CH4_DOB= to_date(J.DOB,'DD/MM/RRRR')  
					WHERE M.SEQ_ID=V_SEQ_ID;
				V_TEMP_COUNTER:=V_TEMP_COUNTER+1;
				CONTINUE;
				END IF;	
			END IF;	

			IF V_TEMP_COUNTER<=V_TEMP_COUNT  THEN 		
				IF V_TEMP_COUNTER =5 THEN 
					UPDATE WELF_TRIP_2017_MAIN M SET
						 CH5_NAME =J.insured_name  ,
						 CH5_DOB= to_date(J.DOB,'DD/MM/RRRR')  
					WHERE M.SEQ_ID=V_SEQ_ID;
				V_TEMP_COUNTER:=V_TEMP_COUNTER+1;
				CONTINUE;
				END IF;				
			END IF;	
				
				

			END LOOP;
---------
END LOOP;

commit;




EXCEPTION
WHEN OTHERS THEN
            raise_application_error(-20001,'An error was encountered - '||SQLCODE||' -ERROR- '||SQLERRM);


END;

/
