-- Create table
create table WELF_TRIP_2017_ROOM
(
  SEQ_ID 	 NUMBER(5),
  ROOM_NO		 VARCHAR2(20),  
  AVAILABLE_DATE         VARCHAR2(50),
  SLOT_1_MAIN_SEQ_ID  	 NUMBER(5),
  SLOT_2_MAIN_SEQ_ID   	 NUMBER(5), 
  SLOT_3_MAIN_SEQ_ID   	 NUMBER(5),
  STATUS  		 VARCHAR2(20),  
  ROOM_GENDER        VARCHAR2(10),
  Primary key (SEQ_ID)
)
tablespace TBS_HNBA_DAT
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );