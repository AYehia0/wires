package main

import (
	"log"

	"github.com/gin-gonic/gin"
)

var (
	SSL_CERT = "/etc/letsencrypt/live/wires.ayehia0.info/fullchain.pem"
	SSL_KEY  = "/etc/letsencrypt/live/wires.ayehia0.info/privkey.pem"
)

func main() {
	// TEST: run server in release mode
	gin.SetMode(gin.ReleaseMode)

	r := gin.Default()
	r.GET("/ping", func(c *gin.Context) {
		c.JSON(200, gin.H{
			"message": "Pong, Pong",
		})
	})

	// check if the server is running on production then enbale http
	if gin.Mode() == gin.ReleaseMode {
		err := r.RunTLS(":443", SSL_CERT, SSL_KEY)
		if err != nil {
			log.Fatal("Failed to start server in release mode: ", err)
		}
	} else {
		r.Run(":8080")
	}
}
