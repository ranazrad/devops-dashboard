FROM nginx:alpine
WORKDIR /usr/share/nginx/html
# מעתיקים ישירות את קבצי ה-Publish המוכנים שהאג'נט בנה
COPY publish/wwwroot .
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
