FROM postgres:13

RUN localedef -i es_PY -c -f UTF-8 -A /usr/share/locale/locale.alias es_PY.UTF-8
ENV LANG es_PY.utf8

ENV POSTGRES_USER admin  
ENV POSTGRES_PASSWORD admin  
ENV POSTGRES_DB ox-crm
