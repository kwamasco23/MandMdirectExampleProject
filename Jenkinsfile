pipeline {
    agent any

    tools {
        // Ensure you have a DotNet SDK installed in Jenkins called "dotnet8"
        dotnet 'dotnet8'
    }

    stages {
        stage('Checkout') {
            steps {
                git branch: 'main', url: 'https://github.com/kwamasco23/MandMdirectExampleProject.git'
            }
        }

        stage('Restore Dependencies') {
            steps {
                bat 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                bat 'dotnet build --configuration Release --no-restore'
            }
        }

        stage('Run SpecFlow Tests') {
            steps {
                // Assumes your SpecFlow tests are set up in the solution
                bat 'dotnet test --no-build --verbosity normal --logger "trx;LogFileName=test_results.trx"'
            }
        }
    }

    post {
        always {
            // Archive test results and binaries
            junit '**/TestResults/*.trx'
            archiveArtifacts artifacts: '**/bin/Release/**/*', allowEmptyArchive: true
        }
        success {
            echo "Build and tests succeeded!"
            // Example for Slack/email notifications:
            // slackSend channel: '#devops', message: "Build SUCCESS: ${env.JOB_NAME} #${env.BUILD_NUMBER}"
        }
        failure {
            echo "Build or tests failed."
            // slackSend channel: '#devops', message: "Build FAILED: ${env.JOB_NAME} #${env.BUILD_NUMBER}"
        }
    }
}
