create table if not exists issue_tag
(
    id                bigserial
        constraint pk_issue_tag primary key,
    issue_id          bigint
        constraint fk_issue_tag_issue_id references issue (id),
    tag_id            bigint
        constraint fk_issue_tag_tag_id references tag (id),
    created_date_time timestamp not null,
    updated_date_time timestamp not null,
    constraint k_issue_tag unique (issue_id, tag_id)
);
