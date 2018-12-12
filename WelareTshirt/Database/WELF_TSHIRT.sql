-- Create table
create table WELF_TSHIRT
(
  COMPANY            VARCHAR2(20),
  EPF_NO             NUMBER(6),
  CONSENT            VARCHAR2(10),
  NO_OF_ITEMS 		 NUMBER(2),
  SYSTEM_DATE        DATE,
  REMARKS            VARCHAR2(250),
  G_EX_SMALL	NUMBER(2),
  G_SMALL		NUMBER(2),
  G_MEDIUM	NUMBER(2),
  G_LARGE	NUMBER(2),
  G_EX_LARGE	NUMBER(2),
  G_DEX_LARGE	NUMBER(2),
  L_EX_SMALL	NUMBER(2),
  L_SMALL		NUMBER(2),
  L_MEDIUM	NUMBER(2),
  L_LARGE	NUMBER(2),
  L_EX_LARGE	NUMBER(2),
  L_DEX_LARGE	NUMBER(2),
  Primary key (COMPANY,EPF_NO)
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
  
  