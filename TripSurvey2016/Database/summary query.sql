select  t.branch_code,t.company,
(
       select count(tt.name) from ws_survey_2016_main tt where tt.branch_code=t.branch_code and tt.company=t.company 
) as "Member Count",
(
       select count(tt.name_of_spouse) from ws_survey_2016_main tt where tt.branch_code=t.branch_code and tt.company=t.company 
) as "Spouse Count",
(
       select sum(tt.no_of_children) from ws_survey_2016_main tt where tt.branch_code=t.branch_code and tt.company=t.company 
) as "kids Count",
(
       select count(*) from ws_survey_2016_ch tt where tt.branch_code=t.branch_code and tt.company=t.company   and tt.ch_sex='M'
) as "kids Count Male",
(
       select count(*) from ws_survey_2016_ch tt where tt.branch_code=t.branch_code and tt.company=t.company  and tt.ch_sex='F'
) as "kids Count Female",

(
     select  count(*) from(select * from ws_survey_2016_ch tt where 
                      to_date(tt.ch_dob,'DD/MM/RRRR')>=to_date('20/08/2013','DD/MM/RRRR') 
         )tt   where   tt.branch_code=t.branch_code and tt.company=t.company 
       
       
) as "kids Count below 3 years",
(
     select  count(*) from(select * from ws_survey_2016_ch tt where 
                      to_date(tt.ch_dob,'DD/MM/RRRR')>=to_date('20/08/2013','DD/MM/RRRR') 
         )tt   where   tt.branch_code=t.branch_code and tt.company=t.company   and tt.ch_sex='M'
       
       
) as "kids Male below 3 years",
(
     select  count(*) from(select * from ws_survey_2016_ch tt where 
                      to_date(tt.ch_dob,'DD/MM/RRRR')>=to_date('20/08/2013','DD/MM/RRRR') 
         )tt   where   tt.branch_code=t.branch_code and tt.company=t.company   and tt.ch_sex='F'
       
       
) as "kids Female below 3 years",



(
     select  count(*) from(select * from ws_survey_2016_ch tt where 
                     ( (to_date(tt.ch_dob,'DD/MM/RRRR')>=to_date('20/08/2010','DD/MM/RRRR')) AND (to_date(tt.ch_dob,'DD/MM/RRRR')<to_date('20/08/2013','DD/MM/RRRR'))) 
         )tt   where   tt.branch_code=t.branch_code and tt.company=t.company 
       
       
) as "kids Count 2-5 years",
(
     select  count(*) from(select * from ws_survey_2016_ch tt where 
                     ( (to_date(tt.ch_dob,'DD/MM/RRRR')>=to_date('20/08/2010','DD/MM/RRRR')) AND (to_date(tt.ch_dob,'DD/MM/RRRR')<to_date('20/08/2013','DD/MM/RRRR'))) 
         )tt   where   tt.branch_code=t.branch_code and tt.company=t.company   and tt.ch_sex='M'
       
       
) as "kids Male 2-5 years",
(
     select  count(*) from(select * from ws_survey_2016_ch tt where 
                     ( (to_date(tt.ch_dob,'DD/MM/RRRR')>=to_date('20/08/2010','DD/MM/RRRR')) AND (to_date(tt.ch_dob,'DD/MM/RRRR')<to_date('20/08/2013','DD/MM/RRRR'))) 
         )tt   where   tt.branch_code=t.branch_code and tt.company=t.company   and tt.ch_sex='F'
       
       
) as "kids Female 2-5 years",


(
     select  count(*) from(select * from ws_survey_2016_ch tt where 
                     ( (to_date(tt.ch_dob,'DD/MM/RRRR')>=to_date('20/08/2007','DD/MM/RRRR')) AND (to_date(tt.ch_dob,'DD/MM/RRRR')<to_date('20/08/2010','DD/MM/RRRR'))) 
         )tt   where   tt.branch_code=t.branch_code and tt.company=t.company 
       
       
) as "kids Count below 6-8 years",

(
     select  count(*) from(select * from ws_survey_2016_ch tt where 
                     ( (to_date(tt.ch_dob,'DD/MM/RRRR')>=to_date('20/08/2007','DD/MM/RRRR')) AND (to_date(tt.ch_dob,'DD/MM/RRRR')<to_date('20/08/2010','DD/MM/RRRR'))) 
         )tt   where   tt.branch_code=t.branch_code and tt.company=t.company   and tt.ch_sex='M'
       
       
) as "kids Male below 6-8 years",

(
     select  count(*) from(select * from ws_survey_2016_ch tt where 
                     ( (to_date(tt.ch_dob,'DD/MM/RRRR')>=to_date('20/08/2007','DD/MM/RRRR')) AND (to_date(tt.ch_dob,'DD/MM/RRRR')<to_date('20/08/2010','DD/MM/RRRR'))) 
         )tt   where   tt.branch_code=t.branch_code and tt.company=t.company   and tt.ch_sex='F'
       
       
) as "kids Female below 6-8 years",

(
     select  count(*) from(select * from ws_survey_2016_ch tt where 
                     ( (to_date(tt.ch_dob,'DD/MM/RRRR')>=to_date('20/08/2006','DD/MM/RRRR')) AND (to_date(tt.ch_dob,'DD/MM/RRRR')<to_date('20/08/2007','DD/MM/RRRR'))) 
      )tt   where   tt.branch_code=t.branch_code and tt.company=t.company 
       
       
) as "kids Count below 9-10 years",
(
     select  count(*) from(select * from ws_survey_2016_ch tt where 
                     ( (to_date(tt.ch_dob,'DD/MM/RRRR')>=to_date('20/08/2006','DD/MM/RRRR')) AND (to_date(tt.ch_dob,'DD/MM/RRRR')<to_date('20/08/2007','DD/MM/RRRR'))) 
      )tt   where   tt.branch_code=t.branch_code and tt.company=t.company  and tt.ch_sex='M'
       
       
) as "kids Male below 9-10 years",
(
     select  count(*) from(select * from ws_survey_2016_ch tt where 
                     ( (to_date(tt.ch_dob,'DD/MM/RRRR')>=to_date('20/08/2006','DD/MM/RRRR')) AND (to_date(tt.ch_dob,'DD/MM/RRRR')<to_date('20/08/2007','DD/MM/RRRR'))) 
      )tt   where   tt.branch_code=t.branch_code and tt.company=t.company  and tt.ch_sex='F'
       
       
) as "kids Female below 9-10 years",

(
     select  count(*) from(select * from ws_survey_2016_ch tt where 
                      to_date(tt.ch_dob,'DD/MM/RRRR')<=to_date('20/08/2006','DD/MM/RRRR') 
         )tt   where   tt.branch_code=t.branch_code and tt.company=t.company 
       
       
) as "kids Count above 10 years",
(
     select  count(*) from(select * from ws_survey_2016_ch tt where 
                      to_date(tt.ch_dob,'DD/MM/RRRR')<=to_date('20/08/2006','DD/MM/RRRR') 
         )tt   where   tt.branch_code=t.branch_code and tt.company=t.company  and tt.ch_sex='M'
       
       
) as "kids Male above 10 years",

(
     select  count(*) from(select * from ws_survey_2016_ch tt where 
                      to_date(tt.ch_dob,'DD/MM/RRRR')<=to_date('20/08/2006','DD/MM/RRRR') 
         )tt   where   tt.branch_code=t.branch_code and tt.company=t.company  and tt.ch_sex='F'
       
       
) as "kids Female above 10 years"


 from ws_survey_2016_main t
group by t.branch_code,t.company;