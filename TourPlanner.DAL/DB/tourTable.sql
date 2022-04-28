-- Table: public.tours

-- DROP TABLE IF EXISTS public.tours;

CREATE TABLE IF NOT EXISTS public.tours
(
    id character varying COLLATE pg_catalog."default" NOT NULL,
    name character varying COLLATE pg_catalog."default",
    description character varying COLLATE pg_catalog."default",
    startadd character varying COLLATE pg_catalog."default",
    startaddnum character varying COLLATE pg_catalog."default",
    startzip character varying COLLATE pg_catalog."default",
    startcountry character varying COLLATE pg_catalog."default",
    endadd character varying COLLATE pg_catalog."default",
    endaddnum character varying COLLATE pg_catalog."default",
    endzip character varying COLLATE pg_catalog."default",
    endcountry character varying COLLATE pg_catalog."default"
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.tours
    OWNER to postgres;