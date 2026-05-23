
  pipeline {
    agent {
      node { label 'k8s-agent' }
    }
    options {
      timeout(time: 15, unit: 'MINUTES')
    }
    environment {
      REPO_URL      = 'https://github.com/ranazrad/devops-dashboard.git'
      GIT_BRANCH    = 'main'
      REGISTRY_USER = 'rokubato'
      IMAGE_NAME    = 'devops-dashboard'
    }
    stages {
      stage('Clone Repository') {
        steps {
          container('git') {
            git branch: 'main', url: 'https://github.com/ranazrad/devops-dashboard.git'
          }
        }
      }
      stage('Test Application') {
        steps {
          container('dotnet') {
            sh 'dotnet test --configuration Release'
          }
        }
      }
      stage('Build Application') {
        steps {
          container('dotnet') {
            sh 'dotnet publish src/DevopsDashboard.App/DevopsDashboard.App.csproj -c Release -o src/DevopsDashboard.App/publish'
          }
        }
      }
      stage('Build & Push Image (Kaniko)') {
        steps {
          withCredentials([usernamePassword(credentialsId: 'dockerhub', usernameVariable: 'DOCKER_USER', passwordVariable: 'DOCKER_PASS')]) {
            container('kaniko') {
              sh """
                mkdir -p /kaniko/.docker
                AUTH=\$(echo -n "\$DOCKER_USER:\$DOCKER_PASS" | base64 | tr -d '\\n')
                echo '{"auths":{"https://index.docker.io/v1/":{"auth":"'\$AUTH'"}}}' > /kaniko/.docker/config.json

                /kaniko/executor \
                  --context=dir://src/DevopsDashboard.App \
                  --dockerfile=src/DevopsDashboard.App/Dockerfile \
                  --destination=\$REGISTRY_USER/\$IMAGE_NAME:\$BUILD_NUMBER \
                  --skip-push-permission-check
              """
            }
          }
        }
      }
      stage('Deploy to Kubernetes') {
        steps {
          container('kubectl') {
            sh """
              if ! kubectl get deployment/\$IMAGE_NAME --namespace=jenkins > /dev/null 2>&1; then
                echo "Deployment not found. Creating a new one..."
                kubectl create deployment \$IMAGE_NAME --image=\$REGISTRY_USER/\$IMAGE_NAME:\$BUILD_NUMBER --namespace=jenkins
              else
                echo "Deployment found. Updating image..."
                kubectl set image deployment/\$IMAGE_NAME \$IMAGE_NAME=\$REGISTRY_USER/\$IMAGE_NAME:\$BUILD_NUMBER --namespace=jenkins
              fi

              kubectl rollout status deployment/\$IMAGE_NAME --namespace=jenkins
            """
          }
        }
      }
    }
  }
