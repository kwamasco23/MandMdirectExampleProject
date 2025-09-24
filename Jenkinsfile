pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                git branch: 'main', url: 'https://github.com/kwamasco23/MandMdirectExampleProject.git'
            }
        }

        stage('Restore') {
            steps {
                script {
                    docker.image('mcr.microsoft.com/dotnet/sdk:8.0').inside {
                        bat 'dotnet restore'
                    }
                }
            }
        }

        stage('Build') {
            steps {
                script {
                    docker.image('mcr.microsoft.com/dotnet/sdk:8.0').inside {
                        bat 'dotnet build --configuration Release --no-restore'
                    }
                }
            }
        }

        stage('Test') {
            steps {
                script {
                    docker.image('mcr.microsoft.com/dotnet/sdk:8.0').inside {
                        bat 'dotnet test --no-build --verbosity normal'
                    }
                }
            }
        }
    }

    post {
        always {
            archiveArtifacts artifacts: '**/bin/Release/**', allowEmptyArchive: true
            junit '**/TestResults/*.xml'
        }
        success {
            echo 'Build and tests succeeded!'
        }
        failure {
            echo 'Build or tests failed. Check logs!'
        }
    }
}
