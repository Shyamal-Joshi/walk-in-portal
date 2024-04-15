# FROM node:20.11-slim

# WORKDIR /app

# RUN npm install -g @angular/cli

# COPY package* .

# RUN npm install

# COPY . .

# EXPOSE 4200

# CMD ["ng", "serve", "--host", "0.0.0.0"]

FROM node:20.11-slim as baseImg

WORKDIR /app

RUN npm install -g @angular/cli

COPY package* .

RUN npm install

COPY . .

RUN ng build


FROM nginx


COPY --from=baseImg /app/dist/walk-in-portal/browser /usr/share/nginx/html

EXPOSE 80

CMD ["nginx", "-g","daemon off;"]




