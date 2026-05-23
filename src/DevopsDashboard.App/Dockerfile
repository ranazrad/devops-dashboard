FROM nginx:alpine
RUN rm -rf /usr/share/nginx/html/*
WORKDIR /usr/share/nginx/html
COPY publish/wwwroot/ .
RUN chmod -R 755 /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
