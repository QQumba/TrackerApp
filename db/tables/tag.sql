create table if not exists tag
(
    id                bigserial
        constraint pk_tag primary key,
    name              text      not null
        constraint k_tag_name unique,
    created_date_time timestamp not null,
    updated_date_time timestamp not null
);
